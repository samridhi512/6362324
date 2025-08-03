import React, { Component } from 'react';

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0
    };
  }

 
  increment = () => {
    this.setState({ count: this.state.count + 1 });
    this.sayHello();
    this.sayMessage();
  };

 
  sayHello = () => {
    console.log("Hello from React!");
  };

  sayMessage = () => {
    console.log("Static message: Have a great day!");
  };


  decrement = () => {
    this.setState({ count: this.state.count - 1 });
  };

  render() {
    return (
      <div style={{ marginBottom: '20px' }}>
        <h2>Counter: {this.state.count}</h2>
        <button onClick={this.increment}>Increment</button>{' '}
        <button onClick={this.decrement}>Decrement</button>
      </div>
    );
  }
}

export default Counter;
