import React, { useState } from 'react';

function Register() {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const { name, email, password } = formData;
    let errors = [];

    if (name.length < 5) {
      errors.push('Name must be at least 5 characters');
    }

    if (!(email.includes('@') && email.includes('.'))) {
      errors.push('Email must contain @ and .');
    }

    if (password.length < 8) {
      errors.push('Password must be at least 8 characters');
    }

    if (errors.length > 0) {
      alert(errors.join('\n')); // Show all errors in one popup
    } else {
      alert(`Hello ${name}, your email is ${email} and password is ${password}`);
    }
  };

  return (
    <div style={{
      fontFamily: 'Arial',
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      height: '100vh',
      backgroundColor: '#f2f2f2'
    }}>
      <div style={{ marginRight: '50px' }}>
        <h1 style={{ color: 'red' }}>Register Here!!!</h1>
      </div>

      <form onSubmit={handleSubmit} style={{
        backgroundColor: 'white',
        padding: '30px',
        borderRadius: '10px',
        boxShadow: '0 0 8px rgba(0,0,0,0.1)',
        width: '300px'
      }}>
        <label>Name:</label>
        <input
          type="text"
          name="name"
          value={formData.name}
          onChange={handleChange}
          style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
        />

        <label>Email:</label>
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
        />

        <label>Password:</label>
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          style={{ width: '100%', padding: '8px', marginBottom: '10px' }}
        />

        <div style={{ textAlign: 'center', marginTop: '15px' }}>
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
  );
}

export default Register;
