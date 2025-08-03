import React from 'react';

function UserPage({ onLogout }) {
  return (
    <div style={{ textAlign: 'center' }}>
      <h2 style={{ color: 'green' }}>Welcome Back!</h2>
      <p>You are now logged in ✅</p>

      <button
        onClick={onLogout}
        style={{
          marginTop: '30px',
          padding: '10px 20px',
          fontSize: '16px',
          backgroundColor: '#dc3545',
          color: 'white',
          border: 'none',
          borderRadius: '5px',
          cursor: 'pointer'
        }}
      >
        Logout
      </button>
    </div>
  );
}

export default UserPage;
