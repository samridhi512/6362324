// ✅ src/components/TrainerDetail.js

import React from 'react';
import { useParams } from 'react-router-dom';
import Trainers from './TrainersMock';

function TrainerDetail() {
  const { id } = useParams();
  const trainer = Trainers.find(t => t.TrainerId === parseInt(id));

  if (!trainer) return <h3>Trainer not found!</h3>;

  return (
    <div>
      <h2>{trainer.Name}'s Details</h2>
      <p><strong>Email:</strong> {trainer.Email}</p>
      <p><strong>Phone:</strong> {trainer.Phone}</p>
      <p><strong>Technology:</strong> {trainer.Technology}</p>
      <p><strong>Skills:</strong> {trainer.Skills.join(', ')}</p>
    </div>
  );
}

export default TrainerDetail; // ✅ Make sure this line exists
