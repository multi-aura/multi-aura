import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";
import "./CreateGroupConversation.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { createGroupConversation } from "../../../services/chatservice";
import SuccessModal from "../../SuccessModal/SuccessModal";
import { debounce } from "lodash"; // Giả sử lodash đã được cài đặt để sử dụng debouncing

const CreateGroupConversation = ({ isVisible, onClose, dataFriend, onCreateGroup }) => {
    const [selectedUsers, setSelectedUsers] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedImage, setSelectedImage] = useState(null);
    const [groupTitle, setGroupTitle] = useState("");
    const [groupData, setGroupData] = useState(null);
    const [imageUrl, setImageUrl] = useState("");
    // Chọn hoặc bỏ chọn người dùng
    const handleSelectUser = (user) => {
        setSelectedUsers((prevUsers) =>
            prevUsers.some((u) => u.userID === user.userID)
                ? prevUsers.filter((u) => u.userID !== user.userID)
                : [...prevUsers, user]
        );
    };

    // Xử lý tải lên ảnh
    const handleImageUpload = (event) => {
        const file = event.target.files[0];
        setImageUrl(file);
        if (file && file.type.startsWith("image/")) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setSelectedImage(reader.result); // Lưu URL dữ liệu ảnh
            };
            reader.readAsDataURL(file);
        } else {
            alert("Vui lòng chọn tệp ảnh hợp lệ.");
        }
    };
    



    const hanleSubmit = () => {
        const groupData = {
            title: groupTitle,
            image:imageUrl,
            users: [...selectedUsers.map((user) => user.userID)],
        };
        onCreateGroup(groupData); 
    }

    if (!isVisible) return null;

    return ReactDOM.createPortal(
        <>
            <div className="create-group-overlay">
                <div className="create-group-container">
                    <div className="create-group-header">
                        <h3>Tạo nhóm</h3>
                        <button onClick={onClose} className="create-group-close-btn">
                            <FontAwesomeIcon icon={faTimes} />
                        </button>
                    </div>
                    <div className="create-group-body">
                        <div className="group-name-container">
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
                                    value={groupTitle}
                                    onChange={(e) => setGroupTitle(e.target.value)}
                                />
                            </div>
                            <div className="input-search-wrapper">
                                <i className="fas fa-search search-icon"></i>
                                <input
                                    type="text"
                                    className="create-group-search-input"
                                    placeholder="Nhập tên hoặc số điện thoại"
                                    value={searchTerm}
                                    onChange={debounce((e) => setSearchTerm(e.target.value), 500)}
                                />
                            </div>
                        </div>
                        <div className="create-group-user-list-container">
                            <div className="create-group-user-list">
                                {Array.isArray(dataFriend) &&
                                    dataFriend
                                        .filter((user) => user.fullname?.toLowerCase().includes(searchTerm.toLowerCase()))
                                        .map((user) => (
                                            <div key={user.userID} className="create-group-user-item">
                                                <input
                                                    type="checkbox"
                                                    checked={selectedUsers.some((u) => u.userID === user.userID)}
                                                    onChange={() => handleSelectUser(user)}
                                                />
                                                <img
                                                    src={user.avatar || "/path/to/default-avatar.png"}
                                                    alt={user.fullname}
                                                    className="create-group-avatar"
                                                />
                                                <span>{user.fullname}</span>
                                            </div>
                                        ))}
                            </div>
                            <div className="create-group-selected-users">
                                <p>Đã chọn {selectedUsers.length}/100</p>
                                {selectedUsers.map((user) => (
                                    <div key={user.userID} className="create-group-selected-user">
                                        <img
                                            src={user.avatar || "/path/to/default-avatar.png"}
                                            alt={user.fullname}
                                            className="create-group-avatar"
                                        />
                                        <span>{user.fullname}</span>
                                        <button
                                            onClick={() =>
                                                setSelectedUsers(
                                                    selectedUsers.filter((u) => u.userID !== user.userID)
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
                    <div className="create-group-footer">
                        <button className="btn btn-outline-light" onClick={onClose}>
                            Hủy
                        </button>
                        <button
                            className="btn btn-success"
                            disabled={selectedUsers.length === 0 || !groupTitle}
                            onClick={hanleSubmit}
                        >
                            Tạo nhóm
                        </button>
                    </div>
                </div>
            </div>
        </>,
        document.body
    );
};

export default CreateGroupConversation;
