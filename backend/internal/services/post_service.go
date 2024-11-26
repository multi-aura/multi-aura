package services

import (
	"errors"
	"multiaura/internal/models"
	"multiaura/internal/repositories"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

type PostService interface {
	GetPostByID(id string) (*models.Post, error)
	CreatePost(post *models.CreatePostRequest) (*models.Post, error)
	UpdatePost(id string, updates *map[string]interface{}) error
	DeletePost(id, userID string) error
	GetRecentPosts(userID string, limit int64, page int64) ([]*models.Post, error)
	GetPostsByUser(userID string) ([]*models.Post, error)
	GetCommentsByPostID(postID string) ([]*models.Comment, error)
	GetCommentByID(commentID string) (*models.Comment, error)
	GetReplyCommentByID(commentID, replyID string) (*models.Comment, error)
	CreateComment(postID, userID string, request *models.CreateCommentRequest) (*models.Comment, error)
	AddReplyToComment(commentID string, userID string, request *models.CreateCommentRequest) (*models.Comment, error)
	DeleteComment(commentID string) error
	DeleteReplyFromComment(commentID, replyID string) error
	LikePost(postID string, userID string) error
	UnlikePost(postID string, userID string) error
	LikeComment(commentID string, userID string) error
	UnlikeComment(commentID string, userID string) error
	LikeReplyComment(commentID, replyID string, userID string) error
	UnlikeReplyComment(commentID, replyID string, userID string) error
}

type postService struct {
	repo     repositories.PostRepository
	userRepo repositories.UserRepository
}

func NewPostService(repo *repositories.PostRepository, userRepo *repositories.UserRepository) PostService {
	return &postService{repo: *repo, userRepo: *userRepo}
}

func (s *postService) GetPostByID(id string) (*models.Post, error) {
	post, err := s.repo.GetByID(id)
	if err != nil {
		return nil, errors.New("failed to get post: " + err.Error())
	}
	return post, nil
}

func (s *postService) CreatePost(post *models.CreatePostRequest) (*models.Post, error) {
	user, err := s.userRepo.GetUserSummaryByID(post.UserID)
	if err != nil {
		return nil, errors.New("failed to get user: " + err.Error())
	}

	// images := make([]models.Image, len(post.Images))
	// for i, img := range post.Images {
	// 	images[i] = models.Image{
	// 		URL: img.URL,
	// 		ID:  primitive.NewObjectID(),
	// 	}
	// }

	newPost := &models.Post{
		ID:          primitive.NewObjectID(),
		Description: post.Description,
		Images:      []models.Image{},
		CreatedAt:   time.Now().UTC(),
		CreatedBy:   *user,
		LikedBy:     []models.UserSummary{},
		SharedBy:    []string{},
		Comments:    []models.Comment{},
		UpdatedAt:   time.Now().UTC(),
	}
	err = s.repo.Create(*newPost)
	if err != nil {
		return nil, errors.New("failed to create post: " + err.Error())
	}

	return newPost, nil
}

func (s *postService) UpdatePost(id string, updates *map[string]interface{}) error {
	(*updates)["postID"] = id
	err := s.repo.Update(updates)
	if err != nil {
		return errors.New("failed to update post: " + err.Error())
	}
	return nil
}

func (s *postService) DeletePost(id, userID string) error {
	post, err := s.repo.GetByID(id)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("post not found")
		}
		return errors.New("failed to get post: " + err.Error())
	}

	if post.CreatedBy.ID != userID {
		return errors.New("unauthorized")
	}

	err = s.repo.Delete(id)
	if err != nil {
		return errors.New("failed to delete post: " + err.Error())
	}

	return nil
}

func (s *postService) GetRecentPosts(userID string, limit int64, page int64) ([]*models.Post, error) {
	followings, err := s.userRepo.GetFollowings(userID)
	if err != nil {
		return nil, errors.New("failed to fetch followings: " + err.Error())
	}

	userIDs := []string{userID}
	for _, following := range followings {
		userIDs = append(userIDs, following.ID)
	}

	posts, err := s.repo.GetRecentPosts(userIDs, limit, page)
	if err != nil {
		return nil, errors.New("failed to get recent posts: " + err.Error())
	}
	return posts, nil
}

func (s *postService) GetPostsByUser(userID string) ([]*models.Post, error) {
	posts, err := s.repo.GetPostsByUser(userID)
	if err != nil {
		return nil, errors.New("failed to fetch posts by user: " + err.Error())
	}
	return posts, nil
}

func (s *postService) GetCommentsByPostID(postID string) ([]*models.Comment, error) {
	comments, err := s.repo.GetCommentsByPostID(postID)
	if err != nil {
		return nil, errors.New("failed to fetch comments by post: " + err.Error())
	}
	return comments, nil
}

func (s *postService) GetCommentByID(commentID string) (*models.Comment, error) {
	comment, err := s.repo.GetCommentByID(commentID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, errors.New("comment not found")
		}
		return nil, errors.New("failed to fetch comment: " + err.Error())
	}

	return comment, nil
}

func (s *postService) GetReplyCommentByID(commentID, replyID string) (*models.Comment, error) {
	reply, err := s.repo.GetReplyCommentByID(commentID, replyID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, errors.New("reply not found")
		}
		return nil, errors.New("failed to fetch reply: " + err.Error())
	}

	return reply, nil
}

func (s *postService) CreateComment(postID, userID string, request *models.CreateCommentRequest) (*models.Comment, error) {
	_, err := s.repo.GetByID(postID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, errors.New("post not found")
		}
		return nil, errors.New("failed to get post: " + err.Error())
	}

	user, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		return nil, errors.New("failed to get user: " + err.Error())
	}

	newComment := &models.Comment{
		ID:        primitive.NewObjectID(),
		ReplyFor:  request.ReplyFor,
		Text:      request.Text,
		Voice:     "",
		Images:    []models.Image{},
		CreatedAt: time.Now().UTC(),
		UpdatedAt: time.Now().UTC(),
		LikedBy:   []string{},
		Replies:   []models.Comment{},
		CreatedBy: *user,
		Status:    "Active",
	}

	err = s.repo.AddComment(postID, *newComment)
	if err != nil {
		return nil, errors.New("failed to add comment: " + err.Error())
	}

	return newComment, nil
}

func (s *postService) AddReplyToComment(commentID string, userID string, request *models.CreateCommentRequest) (*models.Comment, error) {
	user, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		return nil, err
	}

	// Create the new reply comment
	reply := &models.Comment{
		ID:        primitive.NewObjectID(),
		ReplyFor:  request.ReplyFor,
		Text:      request.Text,
		Voice:     "",
		Images:    []models.Image{},
		CreatedAt: time.Now().UTC(),
		UpdatedAt: time.Now().UTC(),
		LikedBy:   []string{},
		Replies:   []models.Comment{},
		CreatedBy: *user,
		Status:    "Active",
	}

	err = s.repo.AddReplyToComment(commentID, *reply)
	if err != nil {
		return nil, err
	}

	return reply, nil
}

func (s *postService) DeleteComment(commentID string) error {
	post, err := s.repo.GetPostByCommentID(commentID)
	if err != nil {
		return err
	}
	if post == nil {
		return errors.New("post not found")
	}

	err = s.repo.DeleteComment(post.ID.Hex(), commentID)
	if err != nil {
		return err
	}

	return nil
}

func (s *postService) DeleteReplyFromComment(commentID, replyID string) error {
	err := s.repo.DeleteReplyFromComment(commentID, replyID)
	if err != nil {
		return err
	}
	return nil
}

func (s *postService) LikePost(postID string, userID string) error {
	userSummary, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("user not found")
		}
		return errors.New("failed to get user: " + err.Error())
	}

	_, err = s.repo.GetByID(postID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("post not found")
		}
		return errors.New("failed to get post: " + err.Error())
	}

	err = s.repo.LikePost(postID, *userSummary)
	if err != nil {
		return errors.New("failed to like post: " + err.Error())
	}

	return nil
}

func (s *postService) UnlikePost(postID string, userID string) error {
	_, err := s.repo.GetByID(postID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("post not found")
		}
		return errors.New("failed to get post: " + err.Error())
	}

	err = s.repo.UnlikePost(postID, userID)
	if err != nil {
		return errors.New("failed to unlike post: " + err.Error())
	}

	return nil
}

func (s *postService) LikeComment(commentID string, userID string) error {
	userSummary, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("user not found")
		}
		return errors.New("failed to get user: " + err.Error())
	}

	err = s.repo.LikeComment(commentID, userSummary.Username)
	if err != nil {
		return errors.New("failed to like comment: " + err.Error())
	}

	return nil
}

func (s *postService) UnlikeComment(commentID string, userID string) error {
	userSummary, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("user not found")
		}
		return errors.New("failed to get user: " + err.Error())
	}

	err = s.repo.UnlikeComment(commentID, userSummary.Username)
	if err != nil {
		return errors.New("failed to unlike comment: " + err.Error())
	}

	return nil
}

func (s *postService) LikeReplyComment(commentID, replyID string, userID string) error {
	userSummary, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("user not found")
		}
		return errors.New("failed to get user: " + err.Error())
	}

	err = s.repo.LikeReplyComment(commentID, replyID, userSummary.Username)
	if err != nil {
		return errors.New("failed to like reply comment: " + err.Error())
	}

	return nil
}

func (s *postService) UnlikeReplyComment(commentID, replyID string, userID string) error {
	userSummary, err := s.userRepo.GetUserSummaryByID(userID)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("user not found")
		}
		return errors.New("failed to get user: " + err.Error())
	}

	err = s.repo.UnlikeReplyComment(commentID, replyID, userSummary.Username)
	if err != nil {
		return errors.New("failed to unlike reply comment: " + err.Error())
	}

	return nil
}
