package controllers

import (
	"multiaura/internal/services"
	APIResponse "multiaura/pkg/api_response"

	"github.com/gofiber/fiber/v2"
)

type ConversationController struct {
	service services.ConversationService
}

// NewConversationController tạo một instance mới của ConversationController
func NewConversationController(service services.ConversationService) *ConversationController {
	return &ConversationController{service}
}

func (cc *ConversationController) CreateConversation(c *fiber.Ctx) error {
	var rep struct {
		UserIDs []string `json:"user_ids"`
		Name    string   `json:"name"`
	}

	// Parse JSON đầu vào
	if err := c.BodyParser(&rep); err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Cannot parse JSON",
			Error:   err.Error(),
		})
	}

	// Kiểm tra đầu vào
	if len(rep.UserIDs) < 2 {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "At least two users are required to create a conversation",
			Error:   "BadRequest",
		})
	}

	// Kiểm tra xem cuộc trò chuyện đã tồn tại hay chưa
	existingConversation, err := cc.service.CheckExistingConversation(rep.UserIDs)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to check existing conversation",
			Error:   err.Error(),
		})
	}

	// Nếu cuộc trò chuyện đã tồn tại, trả về dữ liệu của nó
	if existingConversation != nil {
		return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
			Status:  fiber.StatusOK,
			Message: "Conversation already exists",
			Data:    existingConversation,
		})
	}

	// Tạo cuộc trò chuyện mới
	conversation, err := cc.service.CreateConversation(rep.UserIDs, rep.Name)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Fail to create conversation",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusCreated).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusCreated,
		Message: "Create Conversation successfully",
		Data:    conversation,
	})
}

func (cc *ConversationController) GetConversationByID(c *fiber.Ctx) error {

	conversationID := c.Params("conversationID")
	userID := c.Params("userID")

	if conversationID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Missing conversationID parameter",
			Error:   "BadRequest",
		})
	}
	if userID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Missing userID parameter",
			Error:   "BadRequest",
		})
	}

	// Gọi service để cập nhật trạng thái tin nhắn đã đọc
	err := cc.service.MarkMessagesAsRead(conversationID, userID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Fail to mark messages as read",
			Error:   err.Error(),
		})
	}

	conversation, err := cc.service.GetConversationByID(conversationID)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Fail to get conversation",
			Error:   "StatusInternalServerError",
		})
	}

	// Trả về thông tin cuộc trò chuyện
	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Get Conversation successfully",
		Data:    conversation,
	})
}

func (cc *ConversationController) GetListConversation(c *fiber.Ctx) error {
	userID := c.Params("UserID")

	if userID == "" {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "userID is required",
			Error:   "BadRequest",
		})
	}

	conversation, err := cc.service.GetListConversations(userID)
	if err != nil {
		return c.Status(fiber.StatusOK).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "No get list conversation found",
			Error:   "Internal server error",
		})
	}
	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Get list conversation successfully",
		Data:    conversation,
	})
}
func (cc *ConversationController) AddMember(c *fiber.Ctx) error {
	var req struct {
		ConversationID string   `json:"conversation_id" bson:"conversation_id" form:"conversation_id"`
		UserIDs        []string `json:"user_ids" bson:"user_ids" form:"user_ids"`
	}

	err := c.BodyParser(&req)
	if err != nil {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Cannot parse request body",
			Error:   err.Error(),
		})
	}

	if req.ConversationID == "" || len(req.UserIDs) == 0 {
		return c.Status(fiber.StatusBadRequest).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusBadRequest,
			Message: "Invalid conversation_id or user_ids",
			Error:   "BadRequest",
		})
	}

	addedUsers, err := cc.service.AddMembers(req.ConversationID, req.UserIDs)
	if err != nil {
		return c.Status(fiber.StatusInternalServerError).JSON(APIResponse.ErrorResponse{
			Status:  fiber.StatusInternalServerError,
			Message: "Failed to add members to the conversation",
			Error:   err.Error(),
		})
	}

	return c.Status(fiber.StatusOK).JSON(APIResponse.SuccessResponse{
		Status:  fiber.StatusOK,
		Message: "Members added successfully",
		Data:    addedUsers,
	})
}
