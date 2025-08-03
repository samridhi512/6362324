import React from 'react';

function SectionHeader({ title }) {
  return (
    <div style={{ marginTop: '30px', marginBottom: '10px' }}>
      <h2>{title}</h2>
      <hr style={{ borderTop: '2px solid green' }} />
    </div>
  );
}

export default SectionHeader;
