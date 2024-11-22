package routes

import (
	"multiaura/internal/controllers"
	"multiaura/internal/middlewares"
	"multiaura/internal/repositories"
	"multiaura/internal/services"

	"github.com/gofiber/fiber/v2"
)

func SetupPostRoutes(app *fiber.App) {
	userRepository := repositories.NewUserRepository(neo4jDB)
	postRepository := repositories.NewPostRepository(mongoDB)
	service := services.NewPostService(&postRepository, &userRepository)
	controller := controllers.NewPostController(service)

	posts := app.Group("/post")

	posts.Post("/user/:userID", middlewares.AuthMiddleware(), controller.GetPostsByUser)
	posts.Post("/comments/:postID", middlewares.AuthMiddleware(), controller.GetCommentsByPostID)
	posts.Post("/recents", middlewares.AuthMiddleware(), controller.GetRecentPosts)
	posts.Post("/create", middlewares.AuthMiddleware(), controller.CreatePost)
	posts.Get("/:id", controller.GetPostByID)
}
