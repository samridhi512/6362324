import React from 'react';

function CourseDetails() {
  const courses = [
    { id: 1, title: 'Angular', date: '4/5/2021' },
    { id: 2, title: 'React', date: '6/3/2021' },
  ];

  return (
    <div>
      <h2>📚 <b>Course Details</b></h2>
      {courses.map((course) => (
        <div key={course.id} style={{ marginBottom: '15px' }}>
          <div><b>{course.title}</b></div>
          <div>{course.date}</div>
        </div>
      ))}
    </div>
  );
}

export default CourseDetails;
