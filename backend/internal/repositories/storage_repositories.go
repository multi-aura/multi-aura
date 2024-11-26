package repositories

import "mime/multipart"

type StorageRepository interface {
	UploadFile(file multipart.File, fileHeader *multipart.FileHeader, folder string) (string, error)
	DeleteFile(fileName string) error
}
