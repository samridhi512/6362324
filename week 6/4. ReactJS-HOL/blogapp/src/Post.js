import React from 'react';
import './Post.css'; 

function Post({ title, body }) {
  return (
    <div className="post-card">
      <h2 className="post-title">{title}</h2>
      <p className="post-body">{body}</p>
    </div>
  );
}

export default Post;
