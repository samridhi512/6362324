import React from 'react';
import CourseDetails from './CourseDetails';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';

function App() {
  return (
    <div style={{ fontFamily: 'Arial, sans-serif', padding: '20px' }}>
      <h1 style={{ textAlign: 'center' }}>📘 Blogger Dashboard</h1>

      <div style={{
        display: 'flex',
        justifyContent: 'space-between',
        marginTop: '30px'
      }}>
        <div style={{
          flex: 1,
          padding: '0 20px',
          borderRight: '3px solid green'
        }}>
          <CourseDetails />
        </div>

        <div style={{
          flex: 1,
          padding: '0 20px',
          borderRight: '3px solid green'
        }}>
          <BookDetails />
        </div>

        <div style={{
          flex: 1,
          padding: '0 20px'
        }}>
          <BlogDetails />
        </div>
      </div>
    </div>
  );
}

export default App;
