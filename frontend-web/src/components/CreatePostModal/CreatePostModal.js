import React, { useState } from "react";
import "./CreatePostModal.css";
import MapModal from "../MapModal/MapModal";
import axios from "axios";
import EmojiPicker from "../EmojiPicker/EmojiPicker";
import { getAddressFromCoordinates } from "../../services/exploreSevice";

const CreatePostModal = ({ onClose }) => {
    const [postContent, setPostContent] = useState("");
    const [selectedImages, setSelectedImages] = useState([]);
    const [showMap, setShowMap] = useState(false);
    const [currentLocation, setCurrentLocation] = useState(null);
    const [selectedPosition, setSelectedPosition] = useState(null);
    const [address, setAddress] = useState("Không có địa chỉ");
    const [showEmojiPicker, setShowEmojiPicker] = useState(false);
    const handleInputChange = (event) => {
        setPostContent(event.target.value);
    };
    const onEmojiClick = (emojiObject) => {
        setPostContent((prev) => prev + emojiObject.emoji);
        setShowEmojiPicker(false); // Đóng bảng chọn emoji sau khi chọn
    };
    const handleImageChange = (event) => {
        const files = Array.from(event.target.files);
        const newImages = files.map((file) => URL.createObjectURL(file));
        setSelectedImages((prevImages) => [...prevImages, ...newImages]);
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

    return (
        <div className="unique-post-overlay">
            <div className="unique-post-container">
                <div className="unique-post-header">
                    <button className="unique-post-cancel-btn" onClick={onClose}>
                        Hủy
                    </button>
                    <p className="unique-post-slogan">Cùng Multi-Aura Tạo nên câu chuyện của riêng bạn!</p>
                    <button className="unique-post-close-btn" onClick={onClose}>
                        <i className="fas fa-times"></i>
                    </button>
                </div>

                <div className="unique-post-content">
                    <div className="unique-post-user">
                        <div>
                            <div className="unique-post-header-container">
                                <img
                                    src="https://via.placeholder.com/40"
                                    alt="Avatar"
                                    className="unique-post-avatar"
                                />
                                <div>
                                    <p className="unique-post-username">thang.trong.71216</p>
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
                                    {selectedImages.map((src, index) => (
                                        <div key={index} className="unique-post-image-item">
                                            <img
                                                src={src}
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
                    >
                        Đăng
                    </button>
                </div>

            </div>
        </div>
    );
};

export default CreatePostModal;
