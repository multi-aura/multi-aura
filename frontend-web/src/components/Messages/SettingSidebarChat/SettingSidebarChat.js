import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faBellSlash,
  faThumbtack,
  faUsers,
  faClock,
  faFile,
  faImage,
  faTimes
} from '@fortawesome/free-solid-svg-icons';
import './SettingSidebarChat.css';
import CreateGroupConversation from '../CreateGroupConversation/CreateGroupConversation';

const SettingSidebarChat = ({ isOpen, currentChat, userCurent, dataFriend }) => {
  console.log(dataFriend);
  const [isModalVisible, setModalVisible] = useState(false);
  const isGroup = currentChat.conversation_type === 'Group';
  const currentUserID = userCurent ? userCurent.userID : null;
  let avatar;
  let nameDisplay;
  if (isGroup) {
    avatar = currentChat.thumb_group || '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = currentChat.name_conversation || 'Multi Aura';
  } else {
    const otherUser = currentChat.users.find((user) => user.userID !== currentUserID);
    avatar = otherUser ? otherUser.avatar : '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = otherUser ? otherUser.fullname : 'Unknown User';
  }
  // Hàm mở modal
  const openModal = () => {
    setModalVisible(true);
  };

  // Hàm đóng modal
  const closeModal = () => {
    setModalVisible(false);
  };
  return (
    <div className={`setting-sidebar-chat ${isOpen ? 'visible' : 'hidden'}`}>
      {/* Header */}
      <div className="header">
        <img
          src={avatar}
          alt="Avatar"
        />
        <h3>{nameDisplay}</h3>
        <div className="actions">
          <button>
            <FontAwesomeIcon icon={faBellSlash} /> Tắt thông báo
          </button>
          <button>
            <FontAwesomeIcon icon={faThumbtack} /> Ghim hội thoại
          </button>
          <button onClick={openModal}>
            <FontAwesomeIcon icon={faUsers} /> Tạo nhóm
          </button>
        </div>
      </div>
      <CreateGroupConversation
        isVisible={isModalVisible}
        onClose={closeModal}
      />
      {/* Danh sách nhắc nhở */}
      <div className="section">
        <h4 className="section-title">
          <FontAwesomeIcon icon={faClock} /> Danh sách nhắc nhở
        </h4>
        <p>Không có nhắc nhở nào</p>
      </div>

      {/* Ảnh/Video */}
      <div className="section">
        <h4 className="section-title">
          <FontAwesomeIcon icon={faImage} /> Ảnh/Video
        </h4>
        <div className="media-grid">
          {/* Thêm ảnh */}
          <img src="image1.jpg" alt="Media 1" />
          <img src="image2.jpg" alt="Media 2" />
          <img src="image3.jpg" alt="Media 3" />
          <img src="image4.jpg" alt="Media 4" />
        </div>
        <div className="view-all-btn">Xem tất cả</div>
      </div>

      {/* File */}
      <div className="section">
        <h4 className="section-title">
          <FontAwesomeIcon icon={faFile} /> File
        </h4>
        <ul className="file-list">
          <li>
            <div className="file-name">
              <FontAwesomeIcon icon={faFile} />
              <span>2001216069_File1.xlsx</span>
            </div>
            <div className="file-date">21/11/2024</div>
          </li>
          <li>
            <div className="file-name">
              <FontAwesomeIcon icon={faFile} />
              <span>Nhom10_BaoCaoCuoiKi.zip</span>
            </div>
            <div className="file-date">11/11/2024</div>
          </li>
          <li>
            <div className="file-name">
              <FontAwesomeIcon icon={faFile} />
              <span>EMHUNer.docx</span>
            </div>
            <div className="file-date">10/11/2024</div>
          </li>
        </ul>
        <div className="view-all-btn">Xem tất cả</div>
      </div>


    </div>
  );
};

export default SettingSidebarChat;
