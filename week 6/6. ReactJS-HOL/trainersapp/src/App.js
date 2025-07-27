

import React from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Home from './components/Home';
import TrainersList from './components/TrainersList';
import TrainerDetail from './components/TrainerDetail';
import Trainers from './components/TrainersMock';

function App() {
  return (
    <BrowserRouter>
      <div>
        <nav>
          <Link to="/" style={{ margin: '10px' }}>Home</Link>
          <Link to="/trainers" style={{ margin: '10px' }}>Trainer List</Link>
        </nav>
        <hr />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/trainers" element={<TrainersList trainers={Trainers} />} />
          <Route path="/trainers/:id" element={<TrainerDetail />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
