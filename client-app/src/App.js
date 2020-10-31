import React, { Component } from 'react';
import './App.css';
import Ahorcado from './components/Ahorcado';


class App extends Component {
  render() {
    return (
      <div className="App">
        <Ahorcado />
      </div>
    );
  }
}

export default App;