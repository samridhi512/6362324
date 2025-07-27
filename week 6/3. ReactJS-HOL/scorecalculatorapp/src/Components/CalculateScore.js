import React from 'react';
import '../Stylesheets/mystyle.css';

function CalculateScore() {
  const name = "Samridhi Shree";
  const school = "KIIT University";
  const total = 287;
  const maxMarks = 300;
  const score = ((total / maxMarks) * 100).toFixed(2); // 95.67%

  return (
    <div className="main-container">
      <h1 className="heading">Student Details:</h1>

      <p><span className="label name-label">Name:</span> <span className="value name-value">{name}</span></p>
      <p><span className="label school-label">School:</span> <span className="value school-value">{school}</span></p>
      <p><span className="label total-label">Total:</span> <span className="value total-value">{total} Marks</span></p>
      <p><span className="label score-label">Score:</span> <span className="value score-value">{score}%</span></p>
    </div>
  );
}

export default CalculateScore;
