import React, { useEffect, useState } from 'react';
import Layout from '../layouts/Layout';
import Feed from '../components/Feed/Feed';
import { useLocation, useNavigate } from 'react-router-dom';
import Cookies from 'js-cookie';
import CreatePostModal from '../components/CreatePostModal/CreatePostModal';
import '../assets/css/HomePage.css';
import SuccessModal from '../components/SuccessModal/SuccessModal';
import { createPost, uploadImagePost } from '../services/exploreSevice';
import { getNewsPosts } from '../services/searchService';

function Homepage() {
    const [userData, setUserData] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [buttonPosition, setButtonPosition] = useState({ x: 1820, y: 820 });
    const [dragging, setDragging] = useState(false);
    const [startMousePos, setStartMousePos] = useState({ x: 0, y: 0 });
    const [distanceMoved, setDistanceMoved] = useState(0);
    const navigate = useNavigate();
    const location = useLocation();
    const authToken = Cookies.get('authToken');
    const [showSuccessModal, setShowSuccessModal] = useState(false);
    const [posts, setPosts] = useState([]);  // State to store posts

    // Fetch user data and posts when the component mounts
    useEffect(() => {
        if (!authToken) {
            localStorage.removeItem('activeTab');
            navigate('/');
        } else if (location.state && location.state.userData) {
            setUserData(location.state.userData);
            localStorage.setItem('user', JSON.stringify(location.state.userData));
        } else {
            const storedUser = localStorage.getItem('user');
            if (storedUser) {
                setUserData(JSON.parse(storedUser));
            }
        }
    }, [authToken, location, navigate]);

    // Function to fetch news posts
    const fetchNewsPosts = async () => {
        try {
            const response = await getNewsPosts();
            setPosts(response.data); 
        } catch (error) {
            console.error('Lỗi khi lấy bài viết "News":', error);
        }
    };

    useEffect(() => {
        fetchNewsPosts();
    }, []);  // Run once when the component is mounted

    // Handle mouse events for dragging the floating button
    const handleMouseDown = (event) => {
        setDragging(true);
        setStartMousePos({ x: event.clientX, y: event.clientY });
        setDistanceMoved(0);
    };

    const handleMouseMove = (event) => {
        if (dragging) {
            const distance = Math.sqrt(
                Math.pow(event.clientX - startMousePos.x, 2) +
                Math.pow(event.clientY - startMousePos.y, 2)
            );
            setDistanceMoved(distance);
            setButtonPosition({
                x: event.clientX - 30,
                y: event.clientY - 30,
            });
        }
    };

    const handleMouseUp = () => {
        if (dragging && distanceMoved < 5) {
            setShowModal(true); // Show modal if click
        }
        setDragging(false);
    };

    const handleCloseModal = () => {
        setShowModal(false); // Close modal
    };

    // Handle post submission
    const handlePostSubmit = async (postContent, selectedImages) => {
        try {
            const response = await createPost(postContent);
            const ID_post = response.data._id;

            if (selectedImages.length > 0) {
                const uploadResponse = await uploadImagePost(ID_post, selectedImages);
                if (uploadResponse.status === 200) {
                    setShowSuccessModal(true);
                    setTimeout(() => {
                        handleCloseModal();
                        fetchNewsPosts(); 
                    }, 200);
                }
            } else {
                setShowSuccessModal(true);
                setTimeout(() => {
                    handleCloseModal();
                    fetchNewsPosts(); 
                }, 200);
            }
        } catch (err) {
            console.log('Failed to create post', err); // Handle errors
        }
    };

    return (
        <Layout userData={userData}>
            <Feed posts={posts} /> {/* Pass posts to Feed component */}
            <div
                className="floating-button"
                onMouseDown={handleMouseDown}
                onMouseUp={handleMouseUp}
                onMouseMove={handleMouseMove}
                style={{
                    left: `${buttonPosition.x}px`,
                    top: `${buttonPosition.y}px`,
                }}
                aria-label="Add"
            >
                +
            </div>
            {showModal && (
                <CreatePostModal
                    onClose={handleCloseModal}
                    onPostSubmit={handlePostSubmit}
                    userCurent={userData}
                />
            )}
            {showSuccessModal && (
                <SuccessModal
                    title="Thành công!"
                    description="Cảm ơn bạn đã chia sẻ câu chuyện của mình với cộng đồng."
                    onClose={() => setShowSuccessModal(false)}
                />
            )}
        </Layout>
    );
}

export default Homepage;
