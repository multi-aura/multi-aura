import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";
import "./CreateGroupConversation.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { createGroupConversation } from "../../../services/chatservice";
import SuccessModal from "../../SuccessModal/SuccessModal";

const CreateGroupConversation = ({ isVisible, onClose, dataFriend, onCreateGroup }) => {
    const [selectedUsers, setSelectedUsers] = useState([]);
    const [searchTerm, setSearchTerm] = useState("");
    const [selectedImage, setSelectedImage] = useState(null);
    const [groupTitle, setGroupTitle] = useState("");
    const [userData, setUserData] = useState(null);
    const [isSuccess, setIsSuccess] = useState(false); // Trạng thái thông báo thành công

    const handleSelectUser = (user) => {
        if (selectedUsers.some((u) => u.userID === user.userID)) {
            setSelectedUsers(selectedUsers.filter((u) => u.userID !== user.userID));
        } else {
            setSelectedUsers([...selectedUsers, user]);
        }
    };

    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) {
            setUserData(JSON.parse(storedUser));
        }
    }, []);

    const handleImageUpload = (event) => {
        const file = event.target.files[0];
        if (file && file.type.startsWith("image/")) {
            const imageUrl = URL.createObjectURL(file);
            setSelectedImage(imageUrl);
        } else {
            alert("Vui lòng chọn tệp ảnh hợp lệ.");
        }
    };

    const handleCreateGroupConversation = async () => {
        if (!groupTitle || selectedUsers.length === 0) return;

        const userIDCurent = userData?.userID;
        if (!userIDCurent) {
            console.error("Current user not found");
            return;
        }

        const groupData = {
            title: groupTitle,
            users: [...selectedUsers.map((user) => user.userID), userIDCurent],
        };

        try {
            const name_conversation = groupData.title;
            const userIDs = groupData.users;

            const response = await createGroupConversation(userIDs, name_conversation);
            if (response.status === 201) {
                alert("Bạn đã tạo group thành công");
                setIsSuccess(true); // Hiển thị thông báo thành công
                onClose(); // Đóng popup tạo nhóm
            }
        } catch (err) {
            console.error('Lỗi khi tạo cuộc trò chuyện:', err.message || err);
        }
    };

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
                                    onChange={(e) => setSearchTerm(e.target.value)}
                                />
                            </div>
                        </div>
                        <div className="create-group-user-list-container">
                            <div className="create-group-user-list">
                                {Array.isArray(dataFriend) &&
                                    dataFriend
                                        .filter((user) => {
                                            return (
                                                user.fullname &&
                                                user.fullname.toLowerCase().includes(searchTerm.toLowerCase()) &&
                                                (!userData || user.userID !== userData.userID)
                                            );
                                        })
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
                            onClick={handleCreateGroupConversation}
                        >
                            Tạo nhóm
                        </button>
                    </div>
                </div>
            </div>
            {isSuccess && (
                <SuccessModal
                    title="Tạo nhóm thành công!"
                    description="Nhóm đã được tạo và sẵn sàng sử dụng."
                    onClose={() => setIsSuccess(false)}
                />
            )}
        </>,
        document.body
    );
};

export default CreateGroupConversation;
