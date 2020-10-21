import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';

class App extends Component {
  state = {
    titulo: null
  }

  componentDidMount(){
    this.setState({ titulo: "Ahorcado" })
  }

  render(){
    return (
      <Header as='h1'>
        <Header.Content>{this.state.titulo}</Header.Content>
      </Header>
    );
  }
}

export default App;
