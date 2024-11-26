package controllers

import (
	"multiaura/internal/models"
	"multiaura/internal/services"
	APIResponse "multiaura/pkg/api_response"

	"github.com/gofiber/fiber/v2"
)

type PostController struct {
	service services.PostService
}

func NewPostController(service services.PostService) *PostController {
	return &PostController{service}
}

func (pc *PostController) CreatePost(c *fiber.Ctx) error {
	var req models.CreatePostRequest
	if err := c.BodyParser(&req); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid input",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	req.UserID = userID

	newPost, err := pc.service.CreatePost(&req)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusCreated).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusCreated,
		Message: "Post created successfully",
		Data:    newPost,
	})
}

func (pc *PostController) GetPosts(c *fiber.Ctx) error {
	// posts, err := pc.service.GetPostByID("123")
	// if err != nil {
	// 	return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
	// 		Status:  fiber.StatusInternalServerError,
	// 		Message: err.Error(),
	// 		Error:   "StatusInternalServerError",
	// 	})
	// }

	// return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
	// 	Status:  fiber.StatusOK,
	// 	Message: "Posts retrieved successfully",
	// 	Data:    posts,
	// })

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Did not have logic handle this api",
		Data:    nil,
	})
}

func (pc *PostController) UpdatePost(c *fiber.Ctx) error {
	postID := c.Params("postID")
	var updates map[string]interface{}
	if err := c.BodyParser(&updates); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid input",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	if err := pc.service.UpdatePost(postID, &updates); err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post updated successfully",
		Data:    nil,
	})
}

func (pc *PostController) DeletePost(c *fiber.Ctx) error {
	postID := c.Params("postID")

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	if err := pc.service.DeletePost(postID, userID); err != nil {

		if err.Error() == "unauthorized" {
			return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
				Status:  fiber.StatusUnauthorized,
				Message: "Unauthorized: You do not have permission to delete this post",
				Error:   "StatusUnauthorized",
			})
		}

		if err.Error() == "post not found" {
			return c.Status(fiber.StatusNotFound).JSON(APIResponse.ErrorResponse{
				Status:  fiber.StatusNotFound,
				Message: "Post not found",
				Error:   "StatusNotFound",
			})
		}

		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post deleted successfully",
		Data:    nil,
	})
}

func (pc *PostController) GetPostByID(c *fiber.Ctx) error {
	postID := c.Params("id")

	post, err := pc.service.GetPostByID(postID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	if post == nil {
		return c.Status(fiber.StatusNotFound).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusNotFound,
			Message: "Post not found",
			Error:   "StatusNotFound",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post retrieved successfully",
		Data:    post,
	})
}

func (pc *PostController) GetRecentPosts(c *fiber.Ctx) error {
	userID := c.Locals("userID").(string)
	if userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized access",
			Error:   "StatusUnauthorized",
		})
	}

	var req models.PagingRequest
	if err := c.BodyParser(&req); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid request body",
			Error:   "StatusBadRequest",
		})
	}

	if req.Limit <= 0 {
		req.Limit = 10 // Mặc định limit là 10 nếu không cung cấp hoặc không hợp lệ
	}
	if req.Page <= 0 {
		req.Page = 1 // Mặc định page là 1 nếu không cung cấp hoặc không hợp lệ
	}

	posts, err := pc.service.GetRecentPosts(userID, req.Limit, req.Page)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Posts retrieved successfully",
		Data:    posts,
	})
}

func (pc *PostController) GetPostsByUser(c *fiber.Ctx) error {
	// userID := c.Locals("userID").(string)
	// if userID == "" {
	// 	return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
	// 		Status:  fiber.StatusUnauthorized,
	// 		Message: "Unauthorized access",
	// 		Error:   "StatusUnauthorized",
	// 	})
	// }

	userID := c.Params("userID") // Lấy userID từ URL
	if userID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "User ID is required",
			Error:   "StatusBadRequest",
		})
	}

	posts, err := pc.service.GetPostsByUser(userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Posts retrieved successfully",
		Data:    posts,
	})
}

func (pc *PostController) GetCommentsByPostID(c *fiber.Ctx) error {
	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Post ID is required",
			Error:   "StatusBadRequest",
		})
	}

	comments, err := pc.service.GetCommentsByPostID(postID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comments retrieved successfully",
		Data:    comments,
	})
}

func (pc *PostController) CreateComment(c *fiber.Ctx) error {
	postID := c.Params("postID") // Lấy postID từ params
	if postID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Post ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string) // Lấy userID từ context (middleware)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	var req models.CreateCommentRequest
	if err := c.BodyParser(&req); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid request body",
			Error:   "StatusBadRequest",
		})
	}

	comment, err := pc.service.CreateComment(postID, userID, &req)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusCreated).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusCreated,
		Message: "Comment created successfully",
		Data:    comment,
	})
}

func (pc *PostController) AddReplyToComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID") // Get commentID from the URL
	if commentID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string) // Get userID from the context (middleware)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	var req models.CreateCommentRequest
	if err := c.BodyParser(&req); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid request body",
			Error:   "StatusBadRequest",
		})
	}

	reply, err := pc.service.AddReplyToComment(commentID, userID, &req)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusCreated).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusCreated,
		Message: "Reply added successfully",
		Data:    reply,
	})
}

func (pc *PostController) DeleteComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID")
	userID, ok := c.Locals("userID").(string) // Get userID from the context (middleware)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.DeleteComment(commentID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment deleted successfully",
		Data:    nil,
	})
}

func (pc *PostController) DeleteReplyFromComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID") // Get commentID from the URL
	replyID := c.Params("replyID")     // Get replyID from the URL
	if commentID == "" || replyID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID and Reply ID are required",
			Error:   "StatusBadRequest",
		})
	}

	err := pc.service.DeleteReplyFromComment(commentID, replyID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply deleted successfully",
		Data:    nil,
	})
}

func (pc *PostController) LikePost(c *fiber.Ctx) error {
	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Post ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.LikePost(postID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post liked successfully",
		Data:    nil,
	})
}

func (pc *PostController) UnlikePost(c *fiber.Ctx) error {
	postID := c.Params("postID")
	if postID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Post ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.UnlikePost(postID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Post unliked successfully",
		Data:    nil,
	})
}

func (pc *PostController) LikeComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.LikeComment(commentID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment liked successfully",
		Data:    nil,
	})
}

func (pc *PostController) UnlikeComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID")
	if commentID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID is required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.UnlikeComment(commentID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Comment unliked successfully",
		Data:    nil,
	})
}

func (pc *PostController) LikeReplyComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID")
	replyID := c.Params("replyID")
	if commentID == "" || replyID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID and Reply ID are required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.LikeReplyComment(commentID, replyID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment liked successfully",
		Data:    nil,
	})
}

func (pc *PostController) UnlikeReplyComment(c *fiber.Ctx) error {
	commentID := c.Params("commentID")
	replyID := c.Params("replyID")
	if commentID == "" || replyID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Comment ID and Reply ID are required",
			Error:   "StatusBadRequest",
		})
	}

	userID, ok := c.Locals("userID").(string)
	if !ok || userID == "" {
		return c.Status(fiber.StatusUnauthorized).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusUnauthorized,
			Message: "Unauthorized",
			Error:   "StatusUnauthorized",
		})
	}

	err := pc.service.UnlikeReplyComment(commentID, replyID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: err.Error(),
			Error:   "StatusInternalServerError",
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Reply comment unliked successfully",
		Data:    nil,
	})
}
