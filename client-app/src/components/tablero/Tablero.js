import React, { Component } from 'react';
import Letra from "../letra/Letra";

class Tablero extends Component {
	constructor(props) {
		super(props);
		this.state = {
			letras: "aeioubcdfghjklmnñpqrstvwxyz"
		}
	}

	handleArriesgarLetra = (letra) => {
		this.props.onIngresarLetra && this.props.onIngresarLetra(letra);
	}

	render(){
		return(
			"aeioubcdfghjklmnñpqrstvwxyz".split("").map((letra, index) => {

				const letraIngresada = this.props.letrasIngresadas.filter(x => x.letra === letra).length > 0;

				return (
					<React.Fragment key={index}>
						<Letra
							letra={letra}
							deshabilitada={letraIngresada || this.props.disabled}
							onIngresarLetra={this.handleArriesgarLetra} />
					</React.Fragment>
				)
			})
		)
	}

}

Tablero.defaultProps = {
	disabled: false
};

export default Tablero;