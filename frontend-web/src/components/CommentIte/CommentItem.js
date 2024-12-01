import React, { useState } from 'react';
import { FaHeart, FaReply } from 'react-icons/fa';
import './CommentItem.css';

const CommentItem = ({ comment }) => {
  const [showReplies, setShowReplies] = useState(false);

  // Đảm bảo comment.replies luôn là một mảng
  const replies = Array.isArray(comment.replies) ? comment.replies : [];

  // Xử lý khi người dùng thích bình luận
  const handleLike = () => {
    console.log(`Liked comment with ID: ${comment.id}`);
  };

  // Xử lý khi người dùng trả lời bình luận
  const handleReply = () => {
    console.log(`Replying to comment with ID: ${comment.id}`);
  };

  // Xử lý hiển thị hoặc ẩn danh sách các câu trả lời
  const toggleReplies = () => {
    setShowReplies(prevState => !prevState);
  };
  const getTimeAgo = (createdAt) => {
    const now = new Date();
    const commentTime = new Date(createdAt);
    const diffInMs = now - commentTime; // Difference in milliseconds

    const diffInMinutes = Math.floor(diffInMs / (1000 * 60)); // Convert to minutes
    const diffInHours = Math.floor(diffInMs / (1000 * 60 * 60)); // Convert to hours
    const diffInDays = Math.floor(diffInMs / (1000 * 60 * 60 * 24)); // Convert to days

    if (diffInMinutes < 60) {
      return `${diffInMinutes} minute${diffInMinutes > 1 ? 's' : ''} ago`; // Show minutes
    } else if (diffInHours < 24) {
      return `${diffInHours} hour${diffInHours > 1 ? 's' : ''} ago`; // Show hours
    } else {
      return `${diffInDays} day${diffInDays > 1 ? 's' : ''} ago`; // Show days
    }
  };
  // Hiển thị danh sách câu trả lời nếu có
  const renderReplies = () => {
    return replies.map(reply => (
      <div key={reply.id} className="comment-reply">
        <div className="reply-avatar-container">
          <img
            src={reply.createdBy.avatar}
            alt="Reply Avatar"
            className="reply-avatar"
          />
        </div>
        <div className="reply-content">
          <p>{reply.text}</p>
          <p className="comment-time">{getTimeAgo(reply.createdAt)}</p>

          <div className="reply-actions">
            <button className="reply-like-btn">
              <FaHeart /> {reply.likes}
            </button>
            <button className="reply-reply-btn">
              <FaReply /> Reply
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
        <p>{comment.text}</p>
        <p className="comment-time">{getTimeAgo(comment.createdAt)}</p>
        <div className="comment-actions">
          <button onClick={handleLike} className="comment-like-btn">
            <FaHeart /> {comment.likes}
          </button>
          <button onClick={handleReply} className="comment-reply-btn">
            <FaReply /> Reply
          </button>

          {replies.length > 0 && (
            <button onClick={toggleReplies} className="comment-view-replies-btn">
              {showReplies ? 'Hide replies' : `View ${replies.length} replies`}
            </button>
          )}
        </div>

        {showReplies && <div className="replies">{renderReplies()}</div>}
      </div>
    </div>
  );
};

export default CommentItem;
