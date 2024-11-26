package services

import (
	"errors"
	"fmt"
	"log"
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
		fileName, err := utils.ExtractFileName(url)
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
		log.Println("file:", file)
		fileURL, err := (*s.storageRepo).UploadFile(file, fileHeaders[i], folder)
		if err != nil {
			// Nếu xảy ra lỗi, xóa các file đã upload trước đó
			s.cleanupUploadedFiles(fileURLs)
			return nil, errors.New("failed to upload files")
		}
		fileURLs = append(fileURLs, fileURL)
	}
	log.Println("urls:", fileURLs)

	// Cập nhật thông tin URL của ảnh vào database
	result, err := (*s.postRepo).UploadPhotos(postID, fileURLs)
	if err != nil {
		s.cleanupUploadedFiles(fileURLs)
		return nil, err
	}

	if !result {
		s.cleanupUploadedFiles(fileURLs)
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
			s.cleanupUploadedFiles(fileURLs)
			return nil, fmt.Errorf("failed to upload file: %w", err)
		}
		fileURLs = append(fileURLs, fileURL)
	}

	// Cập nhật URLs vào comment
	if err := (*s.postRepo).UpdateCommentPhotos(post.ID.Hex(), commentID, fileURLs); err != nil {
		s.cleanupUploadedFiles(fileURLs)
		return nil, fmt.Errorf("failed to update comment with photo URLs: %w", err)
	}

	return fileURLs, nil
}

func (s *uploadService) cleanupUploadedFiles(fileURLs []string) {
	for _, fileURL := range fileURLs {
		// Tách tên file từ URL
		fileName, err := utils.ExtractFileName(fileURL)
		if err != nil {
			fmt.Println("Error extracting file name:", err)
			continue
		}

		// Xóa file từ storage
		if err := (*s.storageRepo).DeleteFile(fileName); err != nil {
			fmt.Println("Error deleting file:", fileName, err)
		}
	}
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
			s.cleanupUploadedFiles(fileURLs)
			return nil, fmt.Errorf("failed to upload file: %w", err)
		}
		fileURLs = append(fileURLs, fileURL)
	}

	if err := (*s.postRepo).UpdateReplyCommentPhotos(commentID, replyID, fileURLs); err != nil {
		s.cleanupUploadedFiles(fileURLs)
		return nil, fmt.Errorf("failed to update reply with photo URLs: %w", err)
	}

	return fileURLs, nil
}
