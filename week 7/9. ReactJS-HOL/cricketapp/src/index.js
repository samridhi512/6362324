import React from 'react';
import ReactDOM from 'react-dom/client'; // ✅ Note: '/client' is required in React 18+
import App from './App';

// ✅ Create root and render App
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
