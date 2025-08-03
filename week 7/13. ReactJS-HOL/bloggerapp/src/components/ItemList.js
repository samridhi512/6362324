import React from 'react';

function ItemList({ items, type }) {
  return (
    <ul>
      {items.map((item) => (
        <li key={item.id}>
          {type === 'book' && `${item.title} - ${item.author}`}
          {type === 'blog' && `${item.title} by ${item.author}`}
          {type === 'course' && `${item.title} | Instructor: ${item.instructor}`}
        </li>
      ))}
    </ul>
  );
}

export default ItemList;
