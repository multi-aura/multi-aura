import React, { useState, useRef } from 'react';
import Comment from '../Comment/Comment';
import './Post.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faThumbsUp, faCommentDots, faShare, faHeart, faBookmark } from '@fortawesome/free-solid-svg-icons';
import { FaVolumeUp, FaPauseCircle, FaPlayCircle } from 'react-icons/fa';
import { Carousel } from 'react-bootstrap'; // Import Carousel từ Bootstrap

function Post({ post, userData}) {
  console.log(userData);
  // console.log(post); 
  const [showAllImages, setShowAllImages] = useState(false);
  const [commentText, setCommentText] = useState('');
  const [isPlaying, setIsPlaying] = useState(false);
  const [icon, setIcon] = useState(<FaPlayCircle size={30} />);

  const audioRef = useRef(null);

  const handleImageClick = () => {
    setShowAllImages(!showAllImages); // Toggle việc hiển thị toàn bộ ảnh
  };

  const handlePlayPause = () => {
    const audio = audioRef.current;

    if (isPlaying) {
      audio.pause();
      setIcon(<FaPlayCircle size={30} />);
    } else {
      audio.play().catch((error) => {
        console.error('Error while trying to play audio:', error);
      });
      setIcon(<FaPauseCircle size={30} />); // Change icon to pause
    }

    setIsPlaying(!isPlaying);
  };

  const renderImages = () => {
    const imageCount = post.images.length;

    if (imageCount === 1) {
      return (
        <img
          src={post.images[0].url}
          alt="Post"
          className="img-post img-fluid rounded mb-4"
          style={{
            width: '40%',
            height: 'auto',
            objectFit: 'contain',
            display: 'block',
          }}
        />
      );
    }
    if (imageCount === 2) {
      return (
        <div className="image-row d-flex">
          {post.images.map((image, index) => (
            <img
              key={index}
              src={image.url}
              alt={`Post ${index}`}
              className="img-fluid rounded"
              style={{
                width: '55%',
                marginRight: index === 0 ? '4%' : '0',
                objectFit: 'cover', // Đảm bảo ảnh được cắt bớt phù hợp
              }}
            />
          ))}
        </div>
      );
    }
    if (imageCount > 2) {
      return (
        <div className="image-row">
          <Carousel>
            {post.images.map((image, index) => {
              return (
                <Carousel.Item key={index}>
                  <div className="carousel-image-row">
                    <img
                      className="d-block"
                      src={image.url}
                      alt={`Slide ${index}`}
                      style={{
                        objectFit: 'contain',
                        maxHeight: '700px',
                      }}
                    />
                  </div>
                </Carousel.Item>
              );
            })}
          </Carousel>
        </div>
      );
    }
    
    


    return null;
  };

  const handlePostComment = () => {
    if (commentText.trim()) {
      // Logic to post the comment (you can implement this depending on your app's backend)
      console.log('New comment posted:', commentText);
      setCommentText(''); // Clear the input after posting the comment
    }
  };

  return (
    <div className="post p-3 mb-4 rounded shadow-sm text-white">
      <div className="d-flex align-items-center mb-2" style={{ height: '100%' }}>
        <div className="avatar-container">
          <img
            src={post.avatar || 'https://firebasestorage.googleapis.com/v0/b/multi-aura.appspot.com/o/Hihon%2F393107bb-4c20-44d9-9022-9c900b6b3b71.jpg?alt=media&token=5e41e599-4b72-432b-beb9-6363b2e7b0ce'}
            alt="Avatar"
            className="avatar rounded-circle"
          />
        </div>

        <div className="ml-3">
          <h5 className="text-fullname">{post.createdBy.fullname}</h5>
          <p className="text-time">{new Date(post.createdAt).toLocaleString()}</p>
        </div>
      </div>

      {/* Đoạn ghi âm với biểu tượng play/pause */}
      <p className="content-post">
        <div className="audio-controls">
          <button onClick={handlePlayPause} className="btn audio-btn">
            {icon}
          </button>
          <audio ref={audioRef} src={post.audioUrl} />
        </div>
        <span className="post-description">{post.description}</span>
      </p>

      {renderImages()}

      {showAllImages && (
        <div className="image-grid">
          {post.images.map((image, index) => (
            <img key={index} src={image.url} alt={`Post ${index}`} className="img-fluid rounded mb-4" />
          ))}
        </div>
      )}

      <div className="d-flex justify-content-between align-items-center" style={{ width: "85%" }}>
        <div className="d-flex">
          <button className="btn btn-link text-white mr-3">
            <FontAwesomeIcon icon={faHeart} />
          </button>
          <button className="btn btn-link text-white mr-3">
            <FontAwesomeIcon icon={faCommentDots} />
          </button>
          <button className="btn btn-link text-white mr-3">
            <FontAwesomeIcon icon={faShare} />
          </button>
        </div>
        <button className="btn btn-link text-white">
          <FontAwesomeIcon icon={faBookmark} />
        </button>
      </div>

      <div className="comments mt-3">
        {(post.comments || []).map((comment, index) => (
          <Comment key={index} comment={comment} />
        ))}
      </div>

      <div className="d-flex mt-3">
        <input
          type="text"
          className="form-control comment-text"
          placeholder="Add a comment..."
          value={commentText}
          onChange={(e) => setCommentText(e.target.value)}
        />
        <button className="btn btn-outline-light ml-2" onClick={handlePostComment} disabled={!commentText.trim()}>
          Đăng
        </button>
      </div>
    </div>
  );
}

export default Post;
