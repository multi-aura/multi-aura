package services

import (
	"errors"
	"fmt"
	"mime/multipart"
	"multiaura/internal/models"
	"multiaura/internal/repositories"
	"multiaura/pkg/utils"
)

type UploadService interface {
	UploadProfilePhoto(userID string, file multipart.File, fileHeader *multipart.FileHeader) (string, error)
	UploadPostPhotos(postID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	UploadCommentPhotos(commentID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	UploadReplyCommentPhotos(commentID, replyID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error)
	DeletePostMediaData(postID string) error
	DeleteCommentMediaData(commentID string) error
	DeleteReplyCommentMediaData(commentID, replyID string) error
}

type uploadService struct {
	userRepo    *repositories.UserRepository
	postRepo    *repositories.PostRepository
	storageRepo *repositories.StorageRepository
}

func NewUploadService(userRepo *repositories.UserRepository, postRepo *repositories.PostRepository, storageRepo *repositories.StorageRepository) UploadService {
	return &uploadService{userRepo, postRepo, storageRepo}
}

func (s *uploadService) UploadProfilePhoto(userID string, file multipart.File, fileHeader *multipart.FileHeader) (string, error) {
	url, err := (*s.storageRepo).UploadFile(file, fileHeader, "profile-photos")
	if err != nil {
		return "", err
	}

	result, err := (*s.userRepo).UploadProfilePhoto(userID, url)
	if err != nil {
		return "", err
	}

	if !result {
		fileName, err := utils.ExtractPublicID(url)
		if err != nil {
			return "", err
		} else {
			fmt.Println("File name:", fileName)
		}
		if deleteErr := (*s.storageRepo).DeleteFile(fileName); deleteErr != nil {
			return "", errors.New("failed to upload profile photo, and unable to delete file")
		}
		return "", errors.New("failed to update your profile photo")
	}

	return url, nil
}

func (s *uploadService) UploadPostPhotos(postID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	post, err := (*s.postRepo).GetByID(postID)
	if post == nil {
		return nil, errors.New("post not found")
	}

	if post.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload photos to this post")
	}

	var fileURLs []string
	folder := fmt.Sprintf("posts/%s", postID)

	// Upload từng file và lưu URL của file
	for i, file := range files {
		// log.Println("file:", file)
		fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
		if err != nil {
			// Nếu xảy ra lỗi, xóa các file đã upload trước đó
			s.DeletePhotos(fileURLs)
			return nil, errors.New("failed to upload files")
		}
		fileURLs = append(fileURLs, fileURL)
	}
	// log.Println("urls:", fileURLs)

	// Cập nhật thông tin URL của ảnh vào database
	result, err := (*s.postRepo).UploadPhotos(postID, fileURLs)
	if err != nil {
		s.DeletePhotos(fileURLs)
		return nil, err
	}

	if !result {
		s.DeletePhotos(fileURLs)
		return nil, errors.New("failed to update post with uploaded photos")
	}

	return fileURLs, nil
}

func (s *uploadService) UploadCommentPhotos(commentID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	// Lấy bài viết chứa comment dựa trên commentID
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil {
		return nil, fmt.Errorf("failed to find post by comment ID: %w", err)
	}

	// Tìm comment dựa trên commentID
	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return nil, errors.New("comment not found in the post")
	}

	if targetComment.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload photos to this comment")
	}
	// Chuẩn bị thư mục upload
	folder := fmt.Sprintf("posts/%s/comments/%s", post.ID.Hex(), commentID)

	// Upload các file và lưu URL
	var fileURLs []string
	for i, file := range files {
		fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
		if err != nil {
			// Nếu lỗi, dọn dẹp các file đã upload trước đó
			s.DeletePhotos(fileURLs)
			return nil, fmt.Errorf("failed to upload file: %w", err)
		}
		fileURLs = append(fileURLs, fileURL)
	}

	// Cập nhật URLs vào comment
	if err := (*s.postRepo).UpdateCommentPhotos(post.ID.Hex(), commentID, fileURLs); err != nil {
		s.DeletePhotos(fileURLs)
		return nil, fmt.Errorf("failed to update comment with photo URLs: %w", err)
	}

	return fileURLs, nil
}

func (s *uploadService) UploadReplyCommentPhotos(commentID, replyID, userID string, files []multipart.File, fileHeaders []*multipart.FileHeader) ([]string, error) {
	// Lấy bài viết chứa comment dựa trên commentID
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil {
		return nil, fmt.Errorf("failed to find post by comment ID: %w", err)
	}

	// Tìm comment dựa trên commentID
	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return nil, errors.New("comment not found in the post")
	}

	var targetReply *models.Comment
	for _, reply := range targetComment.Replies {
		if reply.ID.Hex() == replyID {
			targetReply = &reply
			break
		}
	}

	if targetReply == nil {
		return nil, errors.New("reply not found in the comment")
	}

	if targetReply.CreatedBy.ID != userID {
		return nil, errors.New("user is not authorized to upload photos to this reply comment")
	}

	folder := fmt.Sprintf("posts/%s/comments/%s/replies/%s", post.ID.Hex(), commentID, replyID)

	var fileURLs []string
	for i, file := range files {
		fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
		if err != nil {
			s.DeletePhotos(fileURLs)
			return nil, fmt.Errorf("failed to upload file: %w", err)
		}
		fileURLs = append(fileURLs, fileURL)
	}

	if err := (*s.postRepo).UpdateReplyCommentPhotos(commentID, replyID, fileURLs); err != nil {
		s.DeletePhotos(fileURLs)
		return nil, fmt.Errorf("failed to update reply with photo URLs: %w", err)
	}

	return fileURLs, nil
}

func (s *uploadService) DeletePostMediaData(postID string) error {
	post, err := (*s.postRepo).GetByID(postID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var imageUrls []string

	// Duyệt qua các ảnh của post
	for _, image := range post.Images {
		imageUrls = append(imageUrls, image.URL)
	}

	// Duyệt qua các comment và reply comment để xoá ảnh
	for _, comment := range post.Comments {
		// Xoá ảnh của comment
		for _, image := range comment.Images {
			imageUrls = append(imageUrls, image.URL)
		}

		// Duyệt qua các reply comment của comment
		for _, reply := range comment.Replies {
			for _, image := range reply.Images {
				imageUrls = append(imageUrls, image.URL)
			}
		}
	}

	// Gọi hàm DeletePhotos để xoá ảnh
	return s.DeletePhotos(imageUrls)
}

func (s *uploadService) DeleteCommentMediaData(commentID string) error {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var targetComment *models.Comment
	// Duyệt qua các comment để tìm comment cần xoá
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return fmt.Errorf("comment not found")
	}

	var imageUrls []string
	// Xoá ảnh của comment
	for _, image := range targetComment.Images {
		imageUrls = append(imageUrls, image.URL)
	}

	// Duyệt qua các reply comment để xoá ảnh của chúng
	for _, reply := range targetComment.Replies {
		for _, image := range reply.Images {
			imageUrls = append(imageUrls, image.URL)
		}
	}

	// Gọi hàm DeletePhotos để xoá ảnh
	return s.DeletePhotos(imageUrls)
}

func (s *uploadService) DeleteReplyCommentMediaData(commentID, replyID string) error {
	post, err := (*s.postRepo).GetPostByCommentID(commentID)
	if err != nil || post == nil {
		return fmt.Errorf("failed to retrieve post: %w", err)
	}

	var targetComment *models.Comment
	for _, comment := range post.Comments {
		if comment.ID.Hex() == commentID {
			targetComment = &comment
			break
		}
	}

	if targetComment == nil {
		return fmt.Errorf("comment not found")
	}

	var targetReply *models.Comment
	for _, reply := range targetComment.Replies {
		if reply.ID.Hex() == replyID {
			targetReply = &reply
			break
		}
	}

	if targetReply == nil {
		return fmt.Errorf("reply not found")
	}

	var imageUrls []string
	for _, image := range targetReply.Images {
		imageUrls = append(imageUrls, image.URL)
	}

	return s.DeletePhotos(imageUrls)
}

func (s *uploadService) DeletePhotos(images []string) error {
	if len(images) == 0 {
		return nil
	}

	for _, imageURL := range images {
		fileName, err := utils.ExtractPublicID(imageURL)
		if err != nil {
			fmt.Printf("Error extracting file name from URL %s: %v\n", imageURL, err)
			continue
		}

		fmt.Printf("Deleting file %s: \n", fileName)
		if err := (*s.storageRepo).DeleteFile(fileName); err != nil {
			fmt.Printf("Error deleting file %s: %v\n", fileName, err)
		}
	}

	return nil
}
