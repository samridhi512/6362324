import React, { useState } from 'react';

function CurrencyConvertor() {
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState('');

  const handleSubmit = () => {
    if (!rupees || isNaN(rupees)) {
      alert("Please enter a valid amount");
      return;
    }

    const conversionRate = 90; 
    const result = parseFloat(rupees) / conversionRate;
    setEuro(result.toFixed(2));
  };

  return (
    <div style={{ marginBottom: '20px' }}>
      <h3 style={{ color: 'green' }}>Currency Convertor (INR ➜ EURO)</h3>
      <input
        type="number"
        placeholder="Enter amount in ₹"
        value={rupees}
        onChange={(e) => setRupees(e.target.value)}
      />{' '}
      <button onClick={handleSubmit}>Convert</button>
      {euro && <p>€ {euro}</p>}
    </div>
  );
}

export default CurrencyConvertor;
