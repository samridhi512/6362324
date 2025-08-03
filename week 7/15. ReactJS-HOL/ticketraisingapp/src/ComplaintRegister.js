import React, { useState } from 'react';

function ComplaintRegister() {
  const [formData, setFormData] = useState({
    Name: '',
    Complaint: ''
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const transactionId = Math.floor(10 + Math.random() * 90); // Example: 88
    alert(`Thanks ${formData.Name}!\nYour complaint was submitted.\nYour transaction ID is: ${transactionId}`);
  };

  return (
    <div style={{
      fontFamily: 'Arial',
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      height: '100vh',
      backgroundColor: '#f4f4f4'
    }}>
      <div style={{
        backgroundColor: 'white',
        padding: '30px',
        borderRadius: '10px',
        boxShadow: '0 0 10px rgba(0,0,0,0.1)',
        minWidth: '400px'
      }}>
        <h2 style={{ color: 'red', fontWeight: 'bold', textAlign: 'center', marginBottom: '25px' }}>
          Register your complaints here!!!
        </h2>

        <form onSubmit={handleSubmit}>
          <div style={{ display: 'flex', alignItems: 'center', marginBottom: '20px' }}>
            <label style={{ width: '100px' }}>Name:</label>
            <input
              type="text"
              name="Name"
              value={formData.Name}
              onChange={handleChange}
              required
              style={{ flex: 1, padding: '8px' }}
            />
          </div>

          <div style={{ display: 'flex', alignItems: 'center', marginBottom: '20px' }}>
            <label style={{ width: '100px' }}>Complaint:</label>
            <textarea
              name="Complaint"
              value={formData.Complaint}
              onChange={handleChange}
              required
              rows="4"
              style={{ flex: 1, padding: '8px' }}
            />
          </div>

          <div style={{ textAlign: 'center' }}>
            <button
              type="submit"
              style={{
                padding: '10px 20px',
                backgroundColor: '#007bff',
                color: 'white',
                border: 'none',
                borderRadius: '5px',
                cursor: 'pointer'
              }}
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default ComplaintRegister;
