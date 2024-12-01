import React, { useEffect, useState } from 'react';
import Feed from '../../Feed/Feed';
import { getPostsById } from '../../../services/searchService';

function Posts() {
  const [posts, setPosts] = useState([]);
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []); 

  const fetchNewsPosts = async () => {
    if (!userData?.userID) return; 

    try {
      const response = await getPostsById(userData?.userID);
      console.log(response);  // Logs the response from the API
      setPosts(response.data);
    } catch (error) {
      console.error('Lỗi khi lấy bài viết:', error);
    }
  };

  useEffect(() => {
    if (userData) {
      fetchNewsPosts();
    }
  }, [userData]); 

  return (
    <div>
      <Feed posts={posts} userData={userData} />
    </div>
  );
}

export default Posts;
