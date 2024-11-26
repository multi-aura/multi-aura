import React, { useState } from "react";
import ReactDOM from "react-dom";
import "./CreateGroupConversation.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";

const CreateGroupConversation = ({ isVisible, onClose }) => {
    const [selectedUsers, setSelectedUsers] = useState([]); // Danh sách người dùng được chọn
    const [searchTerm, setSearchTerm] = useState(""); // Tìm kiếm người dùng
    const [selectedImage, setSelectedImage] = useState(null); // Ảnh được chọn

    const users = [
        { id: 1, name: "Tớ của tâm", avatar: "https://i.pinimg.com/236x/92/87/38/928738a52b005653d8160ded873e6d4d.jpg" },
        { id: 2, name: "Huy Hoàng", avatar: "https://i.pinimg.com/236x/92/87/38/928738a52b005653d8160ded873e6d4d.jpg" },
        { id: 3, name: "Phạm Thị Kim Phượng", avatar: "https://i.pinimg.com/236x/92/87/38/928738a52b005653d8160ded873e6d4d.jpg" },
        { id: 4, name: "Minh", avatar: "https://i.pinimg.com/236x/92/87/38/928738a52b005653d8160ded873e6d4d.jpg" },
        { id: 5, name: "Nguyễn Minh Hoàng", avatar: "https://i.pinimg.com/236x/92/87/38/928738a52b005653d8160ded873e6d4d.jpg" },
    ];

    const handleSelectUser = (user) => {
        if (selectedUsers.some((u) => u.id === user.id)) {
            setSelectedUsers(selectedUsers.filter((u) => u.id !== user.id));
        } else {
            setSelectedUsers([...selectedUsers, user]);
        }
    };

    const handleImageUpload = (event) => {
        const file = event.target.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = (e) => setSelectedImage(e.target.result);
            reader.readAsDataURL(file);
        }
    };

    if (!isVisible) return null;

    return ReactDOM.createPortal(
        <div className="create-group-overlay">
            <div className="create-group-container">
                {/* Header */}
                <div className="create-group-header">
                    <h3>Tạo nhóm</h3>
                    <button onClick={onClose} className="create-group-close-btn">
                        <FontAwesomeIcon icon={faTimes} />
                    </button>
                </div>

                {/* Body */}
                <div className="create-group-body">
                    <div className="group-name-container">
                        {/* Input chọn ảnh */}
                        <div className="input-with-icon">
                            {selectedImage ? (
                                <img
                                    src={selectedImage}
                                    alt="Group Avatar"
                                    className="group-avatar-preview"
                                    onClick={() => document.getElementById("group-avatar-input").click()}
                                />
                            ) : (
                                <div
                                    className="icon-wrapper"
                                    onClick={() => document.getElementById("group-avatar-input").click()}
                                >
                                    <i className="fas fa-camera"></i>
                                </div>
                            )}

                            <input
                                type="file"
                                id="group-avatar-input"
                                accept="image/*"
                                style={{ display: "none" }}
                                onChange={handleImageUpload}
                            />
                            <input
                                type="text"
                                className="group-name-input"
                                placeholder="Nhập tên nhóm..."
                            />
                        </div>

                        {/* Input tìm kiếm */}
                        <div className="input-search-wrapper">
                            <i className="fas fa-search search-icon"></i>
                            <input
                                type="text"
                                className="create-group-search-input"
                                placeholder="Nhập tên hoặc số điện thoại"
                                value={searchTerm}
                                onChange={(e) => setSearchTerm(e.target.value)}
                            />
                        </div>
                    </div>

                    {/* Danh sách người dùng */}
                    <div className="create-group-user-list-container">
                        <div className="create-group-user-list">
                            {users
                                .filter((user) =>
                                    user.name.toLowerCase().includes(searchTerm.toLowerCase())
                                )
                                .map((user) => (
                                    <div key={user.id} className="create-group-user-item">
                                        <input
                                            type="checkbox"
                                            checked={selectedUsers.some((u) => u.id === user.id)}
                                            onChange={() => handleSelectUser(user)}
                                        />
                                        <img
                                            src={user.avatar}
                                            alt={user.name}
                                            className="create-group-avatar"
                                        />
                                        <span>{user.name}</span>
                                    </div>
                                ))}
                        </div>

                        {/* Người dùng đã chọn */}
                        <div className="create-group-selected-users">
                            <p>Đã chọn {selectedUsers.length}/100</p>
                            {selectedUsers.map((user) => (
                                <div key={user.id} className="create-group-selected-user">
                                    <img
                                        src={user.avatar}
                                        alt={user.name}
                                        className="create-group-avatar"
                                    />
                                    <span>{user.name}</span>
                                    <button
                                        onClick={() =>
                                            setSelectedUsers(
                                                selectedUsers.filter((u) => u.id !== user.id)
                                            )
                                        }
                                        className="remove-user-btn"
                                    >
                                        <FontAwesomeIcon icon={faTimes} />
                                    </button>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>

                {/* Footer */}
                <div className="create-group-footer">
                    <button className="btn btn-outline-light" onClick={onClose}>
                        Hủy
                    </button>
                    <button
                        className="btn btn-success"
                        disabled={selectedUsers.length === 0}
                    >
                        Tạo nhóm
                    </button>
                </div>
            </div>
        </div>,
        document.body
    );
};

export default CreateGroupConversation;
