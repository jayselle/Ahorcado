import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

class Letra extends Component {
	constructor(props) {
		super(props);
		this.state = {
			habilitado: props.habilitado
		}
	}

	handleClick = () => {
		this.setState({habilitado: false}, 
			this.props.onIngresarLetra && this.props.onIngresarLetra(this.props.letra))
	}

	render(){
		return(
			<Button
				value={this.props.letra}
                variant="primary"
                size="lg"
                className="font-weight-bold text-uppercase m-2" 
                onClick={this.handleClick}
                disabled={!this.state.habilitado}>
                {this.props.letra}
            </Button>
		)
	}
}

Letra.defaultProps = {
	habilitado: true
};

export default Letra;