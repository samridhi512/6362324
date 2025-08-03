import React from 'react';

// JSX inline styles
const headingStyle = {
  textAlign: 'center',
  fontSize: '28px',
  margin: '20px',
  color: '#333',
};

// Office List Data
const officeList = [
  {
    name: 'Modern Loft Office',
    rent: 75000,
    address: 'Block A, Phase 1, Electronic City',
    image: process.env.PUBLIC_URL + '/office1.png'
  },
  {
    name: 'Wooden Workspace',
    rent: 58000,
    address: '2nd Floor, MG Road',
    image: process.env.PUBLIC_URL + '/office2.png'
  },
  {
    name: 'Contemporary Office',
    rent: 95000,
    address: 'Whitefield, Bangalore',
    image: process.env.PUBLIC_URL + '/image.png'
  }
];


function App() {
  return (
    <div>
      {/* Heading using JSX */}
      <h1 style={headingStyle}>Office Space Rental</h1>

      {/* Loop through office list using JSX */}
      {officeList.map((office, index) => (
        <div key={index} style={{
          border: '1px solid #ccc',
          padding: '16px',
          margin: '20px',
          borderRadius: '10px',
          boxShadow: '2px 2px 12px #ddd',
          maxWidth: '500px'
        }}>
          <img
  src={office.image}
  alt={office.name}
  style={{
    width: '100%',
    height: '200px',
    objectFit: 'cover',
    borderRadius: '8px'
  }}
/>
          {/* Image attribute */}
          <img src={office.image} alt="office" style={{ width: '100%', borderRadius: '8px' }} />
          <h2>{office.name}</h2>
          <p><strong>Address:</strong> {office.address}</p>
          {/* Rent with conditional inline CSS */}
          <p>
            <strong>Rent:</strong>{' '}
            <span style={{ color: office.rent < 60000 ? 'red' : 'green' }}>
              ₹{office.rent}
            </span>
          </p>
        </div>
      ))}
    </div>
  );
}

export default App;
