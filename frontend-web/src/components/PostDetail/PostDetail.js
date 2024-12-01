import React, { useEffect, useRef, useState } from 'react';
import './PostDetail.css';
import Gallery from 'react-image-gallery';
import { FaEllipsisV, FaVolumeUp, FaPauseCircle, FaPlayCircle } from 'react-icons/fa';
import 'react-image-gallery/styles/css/image-gallery.css'; // Import style của thư viện
import { format } from 'date-fns';
import { FaHeart, FaReply } from 'react-icons/fa';
import CommentsList from '../CommentsList/CommentsList';
// Component to display the post creator's information
function PostCreator({ avatar, fullname, createdAt }) {
    return (
        <div className="post-detail-header">
            <div className='post-detail-header-title'>
                <div className="post-detail-header-left">
                    <img src={avatar} alt="Avatar" className="post-detail-avatar" />
                </div>
                <div className="post-detail-header-right">
                    <p className="post-detail-username">{fullname}</p>
                    <p className="post-detail-fullname">
                        {createdAt ? format(new Date(createdAt), 'dd/MM/yyyy') : 'Ngày không hợp lệ'}
                    </p>
                </div>
            </div>
            <div className="post-detail-header-actions">
                <FaEllipsisV className="post-detail-ellipsis" />
            </div>
        </div>
    );
}




// Main component to display the post details
function PostDetail({ post, closeDetail }) {
    const overlayRef = useRef(null);
    const audioRef = useRef(null);  // Audio ref
    const [commentText, setCommentText] = useState('');
    const [isPlaying, setIsPlaying] = useState(false); // Moved inside the component
    const [icon, setIcon] = useState(<FaPlayCircle size={30} />); // Moved inside the component

    // Handle play/pause audio
    const handlePlayPause = () => {
        const audio = audioRef.current;

        if (!audio) return;

        if (isPlaying) {
            audio.pause();
        } else {
            audio.play().catch((error) => {
                console.error('Error playing audio:', error);
            });
        }
        setIcon(isPlaying ? <FaPlayCircle size={30} /> : <FaPauseCircle size={30} />);
        setIsPlaying(!isPlaying);
    };

    // Close the post detail when clicking outside the component
    const handleClickOutside = (e) => {
        if (overlayRef.current && !overlayRef.current.contains(e.target)) {
            closeDetail();
        }
    };

    useEffect(() => {
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    // Handle comment submission
    const handleCommentSubmit = () => {
        if (commentText.trim()) {
            alert('Bình luận đã được gửi: ' + commentText);
            setCommentText('');
        }
    };

    const renderImages = (images) => {
        if (!images || images.length === 0) {
            return <p>Không có ảnh để hiển thị.</p>;
        }

        const galleryImages = images.map((image) => {
            const isSmallImage = image.width < 600;

            return {
                original: image.url,
                thumbnail: image.url,  // Thumbnails có thể là ảnh nhỏ hơn hoặc các ảnh khác
                originalClass: isSmallImage ? 'resize-image' : 'large-image',  // Apply class based on size
            };
        });

        return <Gallery items={galleryImages} showThumbnails={false} />;
    };


    return (
        <div className="post-detail-overlay">
            <div className="post-detail-container" ref={overlayRef}>
                <div className="post-detail-left">
                    {renderImages(post.images)}
                </div>

                <div className="post-detail-right">
                    <PostCreator
                        avatar={post.createdBy.avatar}
                        fullname={post.createdBy.fullname}
                        createdAt={post.createdAt}
                    />

                    <div className="post-detail-description">
                        {post.voice && (
                            <div className="audio-controls">
                                <button onClick={handlePlayPause} className="btn audio-btn">
                                    {icon}
                                </button>
                                <audio ref={audioRef} src={post.voice} />
                            </div>
                        )}
                        <p className="post-description">{post.description}</p>
                    </div>

                    {/* Comments Section */}
                    <CommentsList comments={post.comments} />

                    {/* Add Comment Section */}
                    <div className="post-detail-add-comment">
                        <div className="comment-input-container">
                            <input
                                type="text"
                                className="comment-input"
                                placeholder="Thêm bình luận..."
                                value={commentText}
                                onChange={(e) => setCommentText(e.target.value)}
                                aria-label="Thêm bình luận"
                            />
                            <button
                                className={`comment-submit-button ${commentText.trim() ? 'active' : ''}`}
                                onClick={handleCommentSubmit}
                                aria-label="Gửi bình luận"
                                disabled={!commentText.trim()}
                            >
                                <i className="fas fa-paper-plane"></i>
                            </button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
}

export default PostDetail;
