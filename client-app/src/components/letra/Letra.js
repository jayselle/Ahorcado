import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

class Letra extends Component {
	constructor(props) {
		super(props);
		this.state = {}
	}

	handleClick = () => {
		this.props.onIngresarLetra && this.props.onIngresarLetra(this.props.letra)
	}

	render(){
		return(
			<Button
				value={this.props.letra}
                variant="primary"
                size="lg"
                className="font-weight-bold text-uppercase m-2" 
                onClick={this.handleClick}
                disabled={this.props.deshabilitada}>
                {this.props.letra}
            </Button>
		)
	}
}

export default Letra;