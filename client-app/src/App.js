import React, { Component } from 'react';
import { Card, Image, Button } from 'react-bootstrap';
import con0intentos from "./images/con0intentos.png";
import con1intentos from "./images/con1intentos.png";
import con2intentos from "./images/con2intentos.png";
import con3intentos from "./images/con3intentos.png";
import con4intentos from "./images/con4intentos.png";
import con5intentos from "./images/con5intentos.png";
import con6intentos from "./images/con6intentos.png";
import Tablero from "./components/tablero/Tablero";
import ResultModal from "./components/modal/ResultModal";
import axios from 'axios';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            modelo: "",
            cantIntentos: 6,
            puntaje: 0,
            letrasIngresadas: [],
            coincidencia: false,
            win: false,
            imagenes: [con0intentos, con1intentos, con2intentos, con3intentos, con4intentos, con5intentos, con6intentos],
            loading: true
        }
    }

    componentDidMount() {
        axios.get('http://localhost:5000/api/config')
            .then(response => {
                this.setState({
                    modelo: response.data.modelo,
                    cantIntentos: response.data.cantIntentos,
                    puntaje: response.data.puntaje,
                    letrasIngresadas: response.data.letrasIngresadas,
                    coincidencia: response.data.coincidencia,
                    win: response.data.win,
                    loading: false
                }, () => this.mostrarResultado())
            })
            .catch(error => {
                console.log(error)
            });;
    }

    generarTablero = () => {
        return(
            <Tablero
                disabled={this.state.cantIntentos === 0 || this.state.win}
                letrasIngresadas={this.state.letrasIngresadas}
                onIngresarLetra={this.arriesgarLetra} />
        )
    }

    arriesgarLetra = (letra) => {
        axios.post('http://localhost:5000/api/ahorcado', { letra: letra })
            .then(response => {
                this.setState({
                    modelo: response.data.modelo,
                    cantIntentos: response.data.cantIntentos,
                    puntaje: response.data.puntaje,
                    letrasIngresadas: response.data.letrasIngresadas,
                    coincidencia: response.data.coincidencia,
                    win: response.data.win
                }, () => this.mostrarResultado())
            })
            .catch(error => {
                console.log(error);
            });
    }

    resetJuego = () => {
        axios.post('http://localhost:5000/api/config', {})
            .then(response => {
                this.setState({
                    modelo: response.data.modelo,
                    cantIntentos: response.data.cantIntentos,
                    puntaje: response.data.puntaje,
                    letrasIngresadas: [],
                    coincidencia: response.data.coincidencia,
                    win: response.data.win
                })
            })
            .catch(error => {
                console.log(error);
            });
    }

    mostrarResultado = () => {
        if (this.state.cantIntentos === 0 || this.state.win)
            this._resultModal.open({ juego: this.state, onReset: this.resetJuego });
    }

    render(){
        if (this.state.loading)
            return null;

        return(
            <React.Fragment>
                <div className="d-flex justify-content-center">
                    <div className="w-75 mt-3">
                        <Card>

                            <Card.Header style={{ fontSize: 50 }} id="title" className="text-center font-weight-bold">
                                ¡AHORCADO!
                            </Card.Header>
                            
                            <Card.Body>

                            <div className="d-flex justify-content-between">
                                <p style={{ fontSize: 30 }} class="text-uppercase font-weight-bold">
                                    Intentos: {this.state.cantIntentos}
                                </p>
                                <p style={{ fontSize: 30 }} class="text-uppercase font-weight-bold">
                                    Puntaje: {this.state.puntaje}
                                </p>
                            </div>

                            <div className="d-flex justify-content-center">
                                <Image
                                    src={this.state.imagenes[this.state.cantIntentos]}
                                    rounded />
                            </div>

                            <Card.Title style={{ fontSize: 40 }} className="text-center font-weight-bold mt-3">
                                {this.state.modelo}
                            </Card.Title>

                            <div className="d-flex justify-content-center">
                                <div className="w-75">
                                    {this.generarTablero()}
                                </div>
                            </div>

                            <div className="d-flex justify-content-end">
                                <Button 
                                    variant="secondary"
                                    className="font-weight-bold text-uppercase m-1" 
                                    onClick={this.resetJuego}
                                    disabled={this.state.puntaje === 0}>
                                    RESET
                                </Button>
                            </div>

                            </Card.Body>
                        </Card>
                    </div>
                </div>

                <ResultModal
                    ref={c => { this._resultModal = c; }} />

            </React.Fragment>)
        }
    }

export default App;