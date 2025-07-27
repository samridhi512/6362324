import React, { Component } from 'react';
import Post from './Post'; 


class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false
    };
  }

  loadPosts = () => {
    fetch('https://jsonplaceholder.typicode.com/posts')

      .then(response => response.json())
      .then(data => this.setState({ posts: data.slice(0, 10) })) // show only 10 posts
      .catch(error => {
        console.error('Fetch error:', error);
        this.setState({ hasError: true });
      });
  };

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    alert("An error occurred in Posts component!");
    console.error("Error info:", info);
  }

  render() {
    if (this.state.hasError) {
      return <h3 style={{ color: 'red' }}>Something went wrong!</h3>;
    }

    return (
      <div>
        <h1>Blog Posts</h1>
        {this.state.posts.map(post => (
          <Post key={post.id} title={post.title} body={post.body} />
        ))}
      </div>
    );
  }
}

export default Posts;
