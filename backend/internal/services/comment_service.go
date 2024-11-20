package services

import (
	"errors"
	"multiaura/internal/models"
	"multiaura/internal/repositories"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

type CommentService interface {
	GetCommentByID(id string) (*models.Comment, error)
	CreateComment(comment *models.CreateCommentRequest) error
	UpdateComment(id string, updates *map[string]interface{}) error
	DeleteComment(id string) error
	GetCommentsByPostID(userID string, limit int64, page int64) ([]*models.Comment, error)
}

type commentService struct {
	repo     repositories.CommentRepository
	userRepo repositories.UserRepository
}

func NewCommentService(repo *repositories.CommentRepository, userRepo *repositories.UserRepository) CommentService {
	return &commentService{repo: *repo, userRepo: *userRepo}
}

func (c *commentService) CreateComment(comment *models.CreateCommentRequest) error {
	user, err := c.userRepo.GetUserSummaryByID(comment.UserID)
	if err != nil {
		return errors.New("failed to fetch user: " + err.Error())
	}

	images := make([]models.Image, len(comment.Images))
	for i, img := range comment.Images {
		images[i] = models.Image{
			URL: img.URL,
			ID:  primitive.NewObjectID(),
		}
	}

	newComment := &models.Comment{
		ID:        primitive.NewObjectID(),
		ReplyFor:  comment.ReplyFor,
		Text:      comment.Text,
		Voice:     comment.Voice,
		Images:    images,
		CreatedAt: time.Now(),
		UpdatedAt: time.Now(),
		Status:    "active",
		CreatedBy: *user,
		LikedBy:   nil,
		Replies:   nil,
	}

	err = c.repo.Create(*newComment)
	if err != nil {
		return errors.New("failed to create comment: " + err.Error())
	}

	return nil
}

func (c *commentService) GetCommentByID(id string) (*models.Comment, error) {
	comment, err := c.repo.GetByID(id)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, errors.New("comment not found")
		}
		return nil, errors.New("failed to get comment: " + err.Error())
	}
	return comment, nil
}

func (c *commentService) GetCommentsByPostID(postID string, limit, page int64) ([]*models.Comment, error) {
	comments, err := c.repo.GetCommentsByPostID(postID, limit, page)
	if err != nil {
		return nil, errors.New("failed to fetch comments: " + err.Error())
	}
	return comments, nil
}

func (c *commentService) UpdateComment(id string, updates *map[string]interface{}) error {
	(*updates)["_id"] = id

	err := c.repo.Update(updates)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("comment not found")
		}
		return errors.New("failed to update comment: " + err.Error())
	}
	return nil
}

func (c *commentService) DeleteComment(id string) error {
	err := c.repo.Delete(id)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return errors.New("comment not found")
		}
		return errors.New("failed to delete comment: " + err.Error())
	}
	return nil
}
