package controllers

import (
	"mime/multipart"
	"multiaura/internal/services"
	APIResponse "multiaura/pkg/api_response"

	"github.com/gofiber/fiber/v2"
)

type UploadController struct {
	service services.UploadService
}

func NewUploadController(service services.UploadService) *UploadController {
	return &UploadController{service}
}

func (uc *UploadController) UploadProfilePhoto(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	fileHeader, err := c.FormFile("image")
	if err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid file",
			Error:   err.Error(),
		})
	}

	file, err := fileHeader.Open()
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Unable to open file",
			Error:   err.Error(),
		})
	}
	defer file.Close()

	url, err := uc.service.UploadProfilePhoto(userID, file, fileHeader)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload profile picture",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Profile picture uploaded successfully",
		Data:    fiber.Map{"url": url},
	})
}

func (uc *UploadController) UploadPostPhotos(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing post ID",
			Error:   "PostIDMissing",
		})
	}

	// reader := bytes.NewReader(c.Body())
	// data, err := io.ReadAll(reader)
	// if err != nil {
	// 	return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
	// 		Status:  fiber.StatusInternalServerError,
	// 		Message: "Error reading request body",
	// 		Error:   err.Error(),
	// 	})
	// }
	// log.Println(string(data))

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	// Lấy tất cả các file từ form
	files := form.File["photos"]
	if len(files) == 0 {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No files provided",
			Error:   "NoFilesProvided",
		})
	}

	var openedFiles []multipart.File
	for _, fileHeader := range files {
		file, err := fileHeader.Open()
		if err != nil {
			return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
				Status:  fiber.StatusUnsupportedMediaType,
				Message: "Unable to open file",
				Error:   err.Error(),
			})
		}
		defer file.Close()
		openedFiles = append(openedFiles, file)
	}

	fileURLs, err := uc.service.UploadPostPhotos(postID, userID, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload post photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post photos uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func (uc *UploadController) UploadCommentsPhotos(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	// Lấy tất cả các file từ form
	files := form.File["photos"]
	if len(files) == 0 {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No files provided",
			Error:   "NoFilesProvided",
		})
	}

	var openedFiles []multipart.File
	for _, fileHeader := range files {
		file, err := fileHeader.Open()
		if err != nil {
			return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
				Status:  fiber.StatusUnsupportedMediaType,
				Message: "Unable to open file",
				Error:   err.Error(),
			})
		}
		defer file.Close()
		openedFiles = append(openedFiles, file)
	}

	fileURLs, err := uc.service.UploadCommentPhotos(commentID, userID, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload comment photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment photos uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func (uc *UploadController) UploadReplyCommentsPhotos(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	replyID := c.Params("replyID")
	if replyID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing reply ID",
			Error:   "ReplyIDMissing",
		})
	}

	form, err := c.MultipartForm()
	if err != nil {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Invalid form data",
			Error:   err.Error(),
		})
	}

	files := form.File["photos"]
	if len(files) == 0 {
		return c.Status(fiber.StatusFailedDependency).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusFailedDependency,
			Message: "No files provided",
			Error:   "NoFilesProvided",
		})
	}

	var openedFiles []multipart.File
	for _, fileHeader := range files {
		file, err := fileHeader.Open()
		if err != nil {
			return c.Status(fiber.StatusUnsupportedMediaType).JSON(APIResponse.ErrorResponse{
				Status:  fiber.StatusUnsupportedMediaType,
				Message: "Unable to open file",
				Error:   err.Error(),
			})
		}
		defer file.Close()
		openedFiles = append(openedFiles, file)
	}

	fileURLs, err := uc.service.UploadReplyCommentPhotos(commentID, replyID, userID, openedFiles, files)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to upload reply comment photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment photos uploaded successfully",
		Data:    fiber.Map{"urls": fileURLs},
	})
}

func (uc *UploadController) DeletePostMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing post ID",
			Error:   "PostIDMissing",
		})
	}

	err := uc.service.DeletePostMediaData(postID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete post photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post photos deleted successfully",
		Data:    nil,
	})
}

func (uc *UploadController) DeleteCommentMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	err := uc.service.DeleteCommentMediaData(commentID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete comment photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment photos deleted successfully",
		Data:    nil,
	})
}

func (uc *UploadController) DeleteReplyCommentMediaData(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing comment ID",
			Error:   "CommentIDMissing",
		})
	}

	replyID := c.Params("replyID")
	if replyID == "" {
		return c.Status(fiber.StatusNotAcceptable).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotAcceptable,
			Message: "Missing reply ID",
			Error:   "ReplyIDMissing",
		})
	}

	err := uc.service.DeleteReplyCommentMediaData(commentID, replyID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to delete reply comment photos",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment photos deleted successfully",
		Data:    nil,
	})
}
