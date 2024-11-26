import React, { useEffect, useState } from 'react';
import Layout from '../layouts/Layout';
import Feed from '../components/Feed/Feed';
import { useLocation, useNavigate } from 'react-router-dom';
import Cookies from 'js-cookie';
import CreatePostModal from '../components/CreatePostModal/CreatePostModal'; // Đảm bảo import đúng component modal
import '../assets/css/HomePage.css';

function Homepage() {
    const [userData, setUserData] = useState(null);
    const navigate = useNavigate();
    const location = useLocation();
    const authToken = Cookies.get('authToken');

    const [buttonPosition, setButtonPosition] = useState({ x: 1820, y: 820 }); // Vị trí ban đầu của nút
    const [dragging, setDragging] = useState(false); // Trạng thái kéo
    const [showModal, setShowModal] = useState(false); // Trạng thái hiển thị modal

    const [startMousePos, setStartMousePos] = useState({ x: 0, y: 0 });
    const [distanceMoved, setDistanceMoved] = useState(0); // Khoảng cách di chuyển chuột

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
                x: event.clientX - 30, // Trừ 30 để căn giữa nút
                y: event.clientY - 30,
            });
        }
    };

    const handleMouseUp = () => {
        if (dragging && distanceMoved < 5) {
            setShowModal(true); // Hiển thị modal nếu click
        }
        setDragging(false);
    };

    const handleCloseModal = () => {
        setShowModal(false); // Đóng modal
    };

    return (
        <Layout userData={userData}>
            <Feed />
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
            {showModal && <CreatePostModal onClose={handleCloseModal} />}
        </Layout>
    );
}

export default Homepage;
