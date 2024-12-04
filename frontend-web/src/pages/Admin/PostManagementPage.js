import React, { useState, useEffect } from 'react';
import AdminLayout from '../../layouts/AdminLayout/AdminLayout';
import PostCard from '../../components/Admin/PostCard/PostCard'; 
import { Row, Spinner } from 'react-bootstrap'; 
import { getToxicPosts } from '../../services/toxicService';
import { deletePostByid } from '../../services/exploreSevice';

import '../../assets/css/PostManagementPage.css';

const PostManagementPage = () => {
    const [timePeriod, setTimePeriod] = useState('week');
    const [posts, setPosts] = useState([]); 
    const [loading, setLoading] = useState(false); 

    const handleTimePeriodChange = (event) => {
        setTimePeriod(event.target.value);
    };
    const handleDeletePost = async (postId) => {
        try {
            await deletePostByid(postId);  
            setPosts(posts.filter(post => post._id !== postId));
        } catch (error) {
            console.error('Failed to delete post', error);
        }
    };
    useEffect(() => {
        const fetchPosts = async () => {
            setLoading(true); 
            try {
                const data = await getToxicPosts(10, 1, 0.5);
                console.log("Toxic posts data:", data);
                setPosts(data.data); // Giả sử 'data' là phần chứa các bài viết từ API
            } catch (error) {
                console.error('Failed to fetch toxic posts', error);
            } finally {
                setLoading(false);
            }
        };

        fetchPosts(); 
    }, [timePeriod]); 

    return (
        <AdminLayout>
            <div className="container">
                <h1>Post Management</h1>

                {/* Filter */}
                <div className="mb-4">
                    <select value={timePeriod} onChange={handleTimePeriodChange} className="form-select">
                        <option value="week">This Week</option>
                        <option value="month">This Month</option>
                    </select>
                </div>

                {/* Loading Spinner */}
                {loading ? (
                    <div className="d-flex justify-content-center">
                        <Spinner animation="border" />
                    </div>
                ) : (
                    <Row>
                        {posts && posts.length > 0 ? (
                            posts.map((post) => (
                                <PostCard key={post._id} post={post} onDelete={handleDeletePost} />
                            ))
                        ) : (
                            <p>No toxic posts available.</p>
                        )}
                    </Row>
                )}
            </div>
        </AdminLayout>
    );
};

export default PostManagementPage;
