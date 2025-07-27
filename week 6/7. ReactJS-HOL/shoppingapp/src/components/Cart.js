import React from 'react';

function Cart(props) {
  return (
    <tr>
      <td style={{ color: 'lightgreen' }}>{props.itemname}</td>
      <td style={{ color: 'lightgreen' }}>{props.price}</td>
    </tr>
  );
}

export default Cart;
