import React from 'react';

function SyntheticEventExample() {
  const handleClick = (e) => {
    e.preventDefault(); 
    alert('I was clicked!');
  };

  return (
    <div style={{ marginBottom: '20px' }}>
      <button onClick={handleClick}>OnPress</button>
    </div>
  );
}

export default SyntheticEventExample;
