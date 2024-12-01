import React, { useState, useEffect } from 'react';
import { FaHeart, FaReply } from 'react-icons/fa';
import './CommentItem.css';
import { addReplyComment, LikeComment, unLikeComment } from '../../services/exploreSevice';

const CommentItem = ({ comment }) => {
  const [likesCount, setLikesCount] = useState(comment?.likedBy.length || 0);
  const [showReplies, setShowReplies] = useState(false);
  const [likedComments, setLikedComments] = useState({});
  const [isReplying, setIsReplying] = useState(false);
  const [replyText, setReplyText] = useState('');
  const replies = Array.isArray(comment.replies) ? comment.replies : [];

  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []);

  const UserNameCurrent = userData?.username;

  useEffect(() => {
    setLikedComments(prevState => ({
      ...prevState,
      [comment._id]: comment.likedBy.includes(UserNameCurrent),
    }));
  }, [comment, UserNameCurrent]);

  const handleLikeComment = async () => {
    const newLikedState = !likedComments[comment._id];

    try {
      setLikedComments(prevState => ({
        ...prevState,
        [comment._id]: newLikedState,
      }));

      if (newLikedState) {
        setLikesCount(likesCount + 1);
        await LikeComment(comment._id); // Like comment
      } else {
        setLikesCount(likesCount - 1);
        await unLikeComment(comment._id); // Unlike comment
      }
    } catch (error) {
      console.error('Error while handling like/unlike for comment:', error);
    }
  };


  const handleReply = () => {
    setIsReplying(!isReplying);
  };

  const handleReplyChange = (event) => {
    setReplyText(event.target.value);
  };
  const handleLikeReply = async (replyId) => {

  };
  const handleKeyDown = (e, replyId) => {
    if (!replyId) {
      console.error('Không tìm thấy ID của comment!');
      return;
    }

    if (e.key === 'Enter' && !e.shiftKey) {
      e.preventDefault();
      handleSubmitReply(replyId);
    }
  };


  const handleSubmitReply = async (replyId) => {
    if (!replyText.trim()) return;
    try {
      const respone = await addReplyComment(replyId, replyText);
      setReplyText('');
      setIsReplying(false);
    } catch (error) {
      console.error('Lỗi khi gửi câu trả lời:', error);
    }
  };

  const toggleReplies = () => {
    setShowReplies(prevState => !prevState);
  };

  const getTimeAgo = (createdAt) => {
    const now = new Date();
    const commentTime = new Date(createdAt);
    const diffInMs = now - commentTime;

    const diffInMinutes = Math.floor(diffInMs / (1000 * 60));
    const diffInHours = Math.floor(diffInMs / (1000 * 60 * 60));
    const diffInDays = Math.floor(diffInMs / (1000 * 60 * 60 * 24));

    if (diffInMinutes < 60) {
      return `${diffInMinutes} phút trước`;
    } else if (diffInHours < 24) {
      return `${diffInHours} giờ trước`;
    } else {
      return `${diffInDays} ngày trước`;
    }
  };

  const renderReplies = () => {
    return replies.map((reply) => (
      <div key={reply._id} className="comment-reply">
        <div className="reply-avatar-container">
          <img
            src={reply.createdBy.avatar}
            alt="Reply Avatar"
            className="reply-avatar"
          />
        </div>
        <div className="reply-content">
          <p>{reply.createdBy.fullname}</p>
          <p className="comment-time">{getTimeAgo(reply.createdAt)}</p>
          <p>{reply.text}</p>
          <div className="reply-actions">
            <button className="reply-like-btn" onClick={() => handleLikeReply(reply._id)}>
              <FaHeart size={20} style={{ cursor: 'pointer' }} />
            </button>
            <button className="reply-reply-btn">
              <FaReply /> Trả lời
            </button>
          </div>
        </div>
      </div>
    ));
  };
  return (
    <div className="comment-item">
      <div className="comment-avatar-container">
        <img
          src={comment.createdBy.avatar}
          alt="User Avatar"
          className="comment-avatar"
        />
      </div>

      <div className="comment-content">
        <p>{comment.createdBy.fullname}</p>
        <p className="comment-time">{getTimeAgo(comment.createdAt)}</p>
        <p>{comment.text}</p>

        <div className="comment-actions">
          <button onClick={handleLikeComment} className="comment-like-btn">
            <FaHeart
              size={20}
              color={likedComments[comment._id] ? 'red' : 'gray'}
            />
            <span>{likesCount}</span>
          </button>
          <button onClick={handleReply} className="comment-reply-btn">
            <FaReply /> Trả lời
          </button>

          {replies.length > 0 && (
            <button onClick={toggleReplies} className="comment-view-replies-btn">
              {showReplies ? 'Ẩn các trả lời' : `Xem ${replies.length} trả lời`}
            </button>
          )}
        </div>

        {showReplies && <div className="replies">{renderReplies()}</div>}

        {isReplying && (
          <div className="reply-input-container">
            <textarea
              value={replyText}
              onChange={handleReplyChange}
              onBlur={() => setIsReplying(false)} // Đóng trả lời khi nhấn ra ngoài
              onKeyDown={(e) => handleKeyDown(e, comment._id)} // Truyền thêm ID comment
              placeholder="Nhập câu trả lời..."
            />
          </div>
        )}





      </div>
    </div>
  );
};

export default CommentItem;
