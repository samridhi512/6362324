import React from 'react';

function GuestPage({ onLogin }) {
  return (
    <div style={{ textAlign: 'center' }}>
      <h2 style={{ color: 'crimson' }}>Please Sign Up to Book Tickets</h2>
      <p>You must be logged in to continue.</p>

      <button
        onClick={onLogin}
        style={{
          marginTop: '20px',
          padding: '10px 20px',
          fontSize: '16px',
          backgroundColor: '#007bff',
          color: 'white',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer'
        }}
      >
        Login
      </button>
    </div>
  );
}

export default GuestPage;
