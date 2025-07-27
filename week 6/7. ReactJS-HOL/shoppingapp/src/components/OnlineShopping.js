import React, { Component } from 'react';
import Cart from './Cart'; // if you're using Cart inside this file

class OnlineShopping extends Component {
  render() {
    const cartItems = [
      { itemname: 'Laptop', price: 80000 },
      { itemname: 'TV', price: 120000 },
      { itemname: 'Washing Machine', price: 50000 },
      { itemname: 'Mobile', price: 30000 },
      { itemname: 'Fridge', price: 70000 },
    ];

    return (
      <div>
        <h2 style={{ color: 'green', textAlign: 'center' }}>Items Ordered :</h2>
        <table align="center" border="1" cellPadding="10">
          <thead>
            <tr>
              <th>Name</th>
              <th>Price</th>
            </tr>
          </thead>
          <tbody>
            {cartItems.map((item, index) => (
              <Cart key={index} itemname={item.itemname} price={item.price} />
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default OnlineShopping;
