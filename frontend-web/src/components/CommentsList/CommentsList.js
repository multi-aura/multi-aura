import React from 'react';
import CommentItem from '../CommentIte/CommentItem';

const CommentsList = ({ comments = [] }) => {
    return (
      <div className="comments-list">
        {comments.map((comment) => (
          <CommentItem key={comment._id} comment={comment} />
        ))}
      </div>
    );
  };
  
  export default CommentsList;
  

