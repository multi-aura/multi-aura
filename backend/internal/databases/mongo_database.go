package databases

import (
	"context"
	config "multiaura/internal/configs/dev"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

type MongoDB struct {
	Client   *mongo.Client
	Database *mongo.Database
}

var mongoInstance *MongoDB

func MongoInstance() *MongoDB {
	return mongoInstance
}

func NewMongoDB(cfg *config.MongoConfig) (*MongoDB, error) {
	if mongoInstance != nil {
		return mongoInstance, nil // Nếu đã có kết nối, trả về instance hiện tại
	}

	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	client, err := mongo.Connect(ctx, options.Client().ApplyURI(cfg.URI))
	if err != nil {
		return nil, err
	}

	// Kiểm tra kết nối
	if err = client.Ping(ctx, nil); err != nil {
		return nil, err
	}

	mongoInstance = &MongoDB{
		Client:   client,
		Database: client.Database(cfg.Database),
	}

	return mongoInstance, nil
}

// Disconnect đóng kết nối MongoDB
func (db *MongoDB) Disconnect() {
	if err := db.Client.Disconnect(context.TODO()); err != nil {
		log.Fatalf("Failed to disconnect from MongoDB: %v", err)
		return
	}
	log.Println("Disconnected from MongoDB!")
}
