package repositories

import (
	"context"
	"multiaura/internal/databases"
	"multiaura/internal/models"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

type CommentRepository interface {
	Repository[models.Comment]
	GetCommentsByPostID(postID string, limit, page int64) ([]*models.Comment, error)
}

type commentRepository struct {
	db         *databases.MongoDB
	collection *mongo.Collection
}

// NewCommentRepository creates a new instance of CommentRepository.
func NewCommentRepository(db *databases.MongoDB) CommentRepository {
	return &commentRepository{
		db:         db,
		collection: db.Database.Collection("comments"),
	}
}

// GetByID fetches a comment by its ID.
func (repo *commentRepository) GetByID(id string) (*models.Comment, error) {
	var comment models.Comment

	objectID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return nil, err
	}

	filter := bson.M{"_id": objectID}
	err = repo.collection.FindOne(context.Background(), filter).Decode(&comment)
	if err != nil {
		if err == mongo.ErrNoDocuments {
			return nil, nil
		}
		return nil, err
	}

	return &comment, nil
}

// Create inserts a new comment document into the collection.
func (repo *commentRepository) Create(entity models.Comment) error {
	_, err := repo.collection.InsertOne(context.Background(), entity)
	return err
}

// Update updates an existing comment based on a map of fields.
func (repo *commentRepository) Update(entityMap *map[string]interface{}) error {
	objectID, err := primitive.ObjectIDFromHex((*entityMap)["_id"].(string))
	if err != nil {
		return err
	}

	filter := bson.M{"_id": objectID}
	updateQuery := bson.M{"$set": *entityMap}

	result, err := repo.collection.UpdateOne(context.Background(), filter, updateQuery)
	if err != nil {
		return err
	}
	if result.MatchedCount == 0 {
		return mongo.ErrNoDocuments
	}

	return nil
}

// Delete removes a comment document by its ID.
func (repo *commentRepository) Delete(id string) error {
	objectID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		return err
	}

	filter := bson.M{"_id": objectID}
	result, err := repo.collection.DeleteOne(context.Background(), filter)
	if err != nil {
		return err
	}
	if result.DeletedCount == 0 {
		return mongo.ErrNoDocuments
	}

	return nil
}

func (repo *commentRepository) GetCommentsByPostID(postID string, limit, page int64) ([]*models.Comment, error) {
	var comments []*models.Comment

	// Chuyển đổi postID sang ObjectID
	objectID, err := primitive.ObjectIDFromHex(postID)
	if err != nil {
		return nil, err
	}

	// Tạo filter
	filter := bson.M{"replyFor": objectID}

	// Tùy chọn Find
	findOptions := options.Find()
	findOptions.SetLimit(limit)
	findOptions.SetSkip((page - 1) * limit)
	findOptions.SetSort(bson.M{"createdAt": -1})

	// Thực hiện tìm kiếm
	cursor, err := repo.collection.Find(context.Background(), filter, findOptions)
	if err != nil {
		return nil, err
	}
	defer cursor.Close(context.Background())

	// Parse từng tài liệu
	for cursor.Next(context.Background()) {
		var data map[string]interface{}
		if err := cursor.Decode(&data); err != nil {
			return nil, err
		}

		// Parse từ map vào model
		comment, err := new(models.Comment).FromMap(data)
		if err != nil {
			return nil, err
		}

		// Thêm vào danh sách kết quả
		comments = append(comments, comment)
	}

	if err := cursor.Err(); err != nil {
		return nil, err
	}

	return comments, nil
}
