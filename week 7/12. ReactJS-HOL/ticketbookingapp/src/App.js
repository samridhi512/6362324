import React, { useState } from 'react';
import GuestPage from './GuestPage';
import UserPage from './UserPage';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div style={{ fontFamily: 'Arial', padding: '30px' }}>
      <h1 style={{ textAlign: 'center' }}>✈️ Ticket Booking App</h1>
      {isLoggedIn ? (
        <UserPage onLogout={() => setIsLoggedIn(false)} />
      ) : (
        <GuestPage onLogin={() => setIsLoggedIn(true)} />
      )}
    </div>
  );
}

export default App;
