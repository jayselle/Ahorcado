import React, { Component } from 'react';
import { Modal, Button } from 'react-bootstrap';

class ResultModal extends Component {
	constructor(props) {
		super(props);
		this.state = {
			visible: props.visible
		}
	}

	open = (params) =>{
		this.setState({
			visible: true,
			juego: params.juego,
			onReset: params.onReset
		})
	}

	close = () => {
		this.setState({ visible: false })
	}

	handleReset = () => {
		this.close();
		this.state.onReset && this.state.onReset();
	}

	render(){
		const juego = this.state.juego;

		return(
			<Modal
				show={this.state.visible}
				backdrop="static"
				onHide={this.close}>
				<Modal.Header closeButton className={juego && juego.win ? "bg-success" : "bg-danger"}>
					<Modal.Title className="text-white font-weight-bold">
						{juego && juego.win ? "¡Ganaste!" : "¡Perdiste!"}
					</Modal.Title>
				</Modal.Header>

				<Modal.Body>
					<span style={{ fontSize: 20 }} className="text-center">¿Intentar de nuevo?</span>
				</Modal.Body>

				<Modal.Footer>
					<Button variant="secondary" onClick={this.handleReset}>RESET</Button>
				</Modal.Footer>
			</Modal>
		)
	}
}

ResultModal.defaultProps = {
	visible: false
};

export default ResultModal;