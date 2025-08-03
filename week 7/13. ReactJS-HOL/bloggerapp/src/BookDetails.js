import React from 'react';

function BookDetails() {
  const books = [
    { id: 1, title: 'Deep Dive Into Angular 11', price: 670 },
    { id: 2, title: 'Master React', price: 800 },
    { id: 3, title: 'Mongo Essentials', price: 450 },
  ];

  return (
    <div>
      <h2>📖 <b>Book Details</b></h2>
      {books.map((book) => (
        <div key={book.id} style={{ marginBottom: '15px' }}>
          <div><b>{book.title}</b></div>
          <div>{book.price}</div>
        </div>
      ))}
    </div>
  );
}

export default BookDetails;
