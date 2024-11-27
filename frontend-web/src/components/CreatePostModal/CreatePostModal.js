import React, { useState } from "react";
import "./CreatePostModal.css";
import MapModal from "../MapModal/MapModal";
import EmojiPicker from "../EmojiPicker/EmojiPicker";
import ConfirmModal from "../../components/ConfirmModal/ConfirmModal";
import { getAddressFromCoordinates } from "../../services/exploreSevice";

const CreatePostModal = ({ onClose, userCurent, onPostSubmit }) => {

    const [postContent, setPostContent] = useState("");
    const [selectedImages, setSelectedImages] = useState([]);
    const [showMap, setShowMap] = useState(false);
    const [currentLocation, setCurrentLocation] = useState(null);
    const [selectedPosition, setSelectedPosition] = useState(null);
    const [address, setAddress] = useState("Không có địa chỉ");
    const [showEmojiPicker, setShowEmojiPicker] = useState(false);
    const [showConfirmModal, setShowConfirmModal] = useState(false);

    const handleCancel = () => {
        if (postContent || selectedImages.length > 0) {
            setShowConfirmModal(true); // Chỉ hiển thị modal khi có nội dung
        } else {
            onClose();
        }
    };

    const handleClose = () => {
        if (postContent || selectedImages.length > 0) {
            setShowConfirmModal(true); // Mở modal xác nhận
        } else {
            onClose();
        }
    };

    const handleConfirmClose = () => {
        setShowConfirmModal(false); // Đóng modal xác nhận
        onClose(); // Thực hiện hành động đóng modal
    };

    const handleConfirmCancel = () => {
        setShowConfirmModal(false); // Đóng modal xác nhận
        onClose(); // Thực hiện hành động hủy modal
    };

    const handleInputChange = (event) => {
        setPostContent(event.target.value);
    };

    const onEmojiClick = (emojiObject) => {
        setPostContent((prev) => prev + emojiObject.emoji);
        setShowEmojiPicker(false); // Đóng bảng chọn emoji sau khi chọn
    };

    const handleImageChange = (event) => {
        const files = Array.from(event.target.files);
        setSelectedImages((prevImages) => [...prevImages, ...files]);
    };

    const removeImage = (index) => {
        setSelectedImages((prevImages) => prevImages.filter((_, i) => i !== index));
    };

    const handleMapClick = () => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    const latitude = position.coords.latitude;
                    const longitude = position.coords.longitude;

                    setCurrentLocation({ lat: latitude, lng: longitude });
                    setShowMap(true);
                },
                (err) => {
                    console.error("Không thể lấy vị trí:", err);
                    alert("Không thể lấy vị trí của bạn. Vui lòng bật định vị.");
                }
            );
        } else {
            alert("Trình duyệt của bạn không hỗ trợ định vị.");
        }
    };

    const handleMapPositionSelect = async ({ lat, lng }) => {
        setSelectedPosition({ lat, lng });

        try {
            const location = await getAddressFromCoordinates(lat, lng);
            setAddress(location);
            setShowMap(false);
        } catch (error) {
            console.error(error);
            setAddress("Không thể lấy địa chỉ cụ thể");
        }
    };

    const decodeHtmlEntity = (html) => {
        const textarea = document.createElement("textarea");
        textarea.innerHTML = html;
        return textarea.value;
    };

 
    const handleSubmit = () => {
        onPostSubmit(postContent, selectedImages); 
    };
    


    return (
        <div className="unique-post-overlay">
            <div className="unique-post-container">
                <div className="unique-post-header">
                    <button className="unique-post-cancel-btn" onClick={handleCancel}>
                        Hủy
                    </button>
                    <p className="unique-post-slogan">Cùng Multi-Aura Tạo nên câu chuyện của riêng bạn!</p>
                    <button className="unique-post-close-btn" onClick={handleClose}>
                        <i className="fas fa-times"></i>
                    </button>
                </div>

                <div className="unique-post-content">
                    <div className="unique-post-user">
                        <div>
                            <div className="unique-post-header-container">
                                <img
                                    src={userCurent.avatar}
                                    alt="Avatar"
                                    className="unique-post-avatar"
                                />
                                <div>
                                    <p className="unique-post-username">{userCurent.fullname}</p>
                                    {selectedPosition && (
                                        <div className="address-display">
                                            <p className="address-text"> 🌍 {address}</p>
                                        </div>
                                    )}
                                </div>
                            </div>
                            <div className="unique-post-input-container">
                                <textarea
                                    className="unique-post-input"
                                    placeholder="Có gì mới?"
                                    value={postContent} // Nội dung hiện tại, bao gồm cả emoji
                                    onChange={handleInputChange} // Cập nhật nội dung khi người dùng nhập
                                ></textarea>
                            </div>

                            {selectedImages.length > 0 && (
                                <div className="unique-post-images-grid">
                                    {selectedImages.map((file, index) => (
                                        <div key={index} className="unique-post-image-item">
                                            <img
                                                src={URL.createObjectURL(file)}
                                                alt={`Preview ${index}`}
                                                className="unique-post-image-preview"
                                            />
                                            <button
                                                className="unique-post-remove-image-btn"
                                                onClick={() => removeImage(index)}
                                            >
                                                <i className="fas fa-times"></i>
                                            </button>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>

                    <div className="unique-post-icons">
                        <label className="unique-post-image-upload-label">
                            <i className="fas fa-camera unique-post-icon"></i>
                            <input
                                type="file"
                                multiple
                                accept="image/*"
                                onChange={handleImageChange}
                                style={{ display: "none" }}
                            />
                        </label>
                        <i className="fas fa-hashtag unique-post-icon"></i>
                        <i className="fas fa-align-left unique-post-icon"></i>

                        <i
                            className="fas fa-smile unique-post-icon"
                            onClick={() => setShowEmojiPicker((prev) => !prev)}
                        ></i>

                        {showEmojiPicker && (
                            <div
                                className="emoji-picker-container"
                                style={{
                                    position: "absolute",
                                    top: "calc(100% + 10px)", // Đẩy bảng xuống phía dưới
                                    left: "10px",
                                    zIndex: 10,
                                }}
                            >
                                <EmojiPicker
                                    onEmojiClick={(emoji) => {
                                        const decodedEmoji = decodeHtmlEntity(emoji.htmlCode); // Giải mã mã HTML
                                        setPostContent((prev) => prev + decodedEmoji); // Thêm emoji vào nội dung
                                        setShowEmojiPicker(false); // Đóng picker
                                    }}
                                />
                            </div>
                        )}

                        <i
                            className="fas fa-map-marker-alt unique-post-icon"
                            onClick={handleMapClick}
                        ></i>
                    </div>
                </div>

                <MapModal
                    show={showMap}
                    onClose={() => setShowMap(false)}
                    location={currentLocation}
                    onMapClick={handleMapPositionSelect}
                />
            

                <div className="unique-post-footer">
                    <button
                        className="btn btn-outline-success"
                        disabled={!postContent && selectedImages.length === 0}
                        onClick={handleSubmit}
                    >
                        Đăng
                    </button>
                </div>

                {showConfirmModal && (
                    <ConfirmModal
                        slogan=" Multi-Aura chờ bạn ! 😊"
                        message="Bạn có chắc chắn muốn hủy tạo bài đăng?"
                        onConfirm={handleConfirmClose}
                        onCancel={() => setShowConfirmModal(false)}
                    />
                )}
            </div>
        </div>
    );
};

export default CreatePostModal;
