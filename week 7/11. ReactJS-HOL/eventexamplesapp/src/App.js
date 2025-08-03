import React from 'react';
import Counter from './Counter';
import SayWelcome from './SayWelcome';
import SyntheticEventExample from './SyntheticEventExample';
import CurrencyConvertor from './CurrencyConvertor';

function App() {
  return (
    <div style={{ padding: '30px', fontFamily: 'Arial' }}>
      <h1>React Events Example</h1>
      <Counter />
      <SayWelcome />
      <SyntheticEventExample />
      <CurrencyConvertor />
    </div>
  );
}

export default App;
