import React from 'react';

function BlogDetails() {
  const blogs = [
    {
      id: 1,
      title: 'React Learning',
      author: 'Stephen Biz',
      content: 'Welcome to learning React',
    },
    {
      id: 2,
      title: 'Installation',
      author: 'Schwarzden',
      content: 'You can install React from npm.',
    },
  ];

  return (
    <div>
      <h2>📝 <b>Blog Details</b></h2>
      {blogs.map((blog) => (
        <div key={blog.id} style={{ marginBottom: '15px' }}>
          <div><b>{blog.title}</b></div>
          <div>{blog.author}</div>
          <div
            style={blog.content.includes('npm') ? { cursor: 'pointer' } : {}}
          >
            {blog.content}
          </div>
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;
