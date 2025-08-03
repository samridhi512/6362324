import React from 'react';

function SayWelcome() {
  const showMessage = (message) => {
    alert(`Message: ${message}`);
  };

  return (
    <div style={{ marginBottom: '20px' }}>
      <button onClick={() => showMessage('Welcome')}>Say Welcome</button>
    </div>
  );
}

export default SayWelcome;
