import React, { Component } from 'react';
import { Card, Image } from 'react-bootstrap';
import con0intentos from "./images/con0intentos.png";
import con1intentos from "./images/con1intentos.png";
import con2intentos from "./images/con2intentos.png";
import con3intentos from "./images/con3intentos.png";
import con4intentos from "./images/con4intentos.png";
import con5intentos from "./images/con5intentos.png";
import con6intentos from "./images/con6intentos.png";
import Letra from "./components/letra/Letra";
import axios from 'axios';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            cantIntentos: 6,
            puntaje: 0,
            modelo: "",
            letrasIngresadas: [],
            imagenes: [con0intentos, con1intentos, con2intentos, con3intentos, con4intentos, con5intentos, con6intentos],
            loading: true
        }
    }

    componentDidMount() {
        axios.get('http://localhost:5000/api/ahorcado').then(response => {
            this.setState({
                modelo: response.data.modelo,
                cantIntentos: response.data.cantIntentos,
                puntaje: response.data.puntaje,
                letrasIngresadas: response.data.letrasIngresadas,
                loading: false
            });
        });
    }    

    generarTablero() {
        const letrasIngresadas = this.state.letrasIngresadas;
        const tablero = "aeioubcdfghjklmnñpqrstvwxyz".split("").map((letra, index) => {
            return (
                <React.Fragment key={index}>
                    <Letra
                        letra={letra}
                        habilitado={letrasIngresadas.filter(x => x.letra === letra).length <= 0}
                        onIngresarLetra={this.arriesgarLetra} />
                </React.Fragment>
            )
        });

        return tablero;
    }

    arriesgarLetra = (letra) => {
        axios.post('http://localhost:5000/api/ahorcado', { letra: letra })
        .then(response => {
            this.setState({
                modelo: response.data.modelo,
                cantIntentos: response.data.cantIntentos,
                puntaje: response.data.puntaje,
                letrasIngresadas: response.data.letrasIngresadas
            })
        })
        .catch(error => {
            console.log(error);
        });
    }

    render(){
        if (this.state.loading)
            return null;
        
        return(
            <React.Fragment>
                <div className="d-flex justify-content-center">
                    <div className="w-75 mt-3">
                        <Card>

                            <Card.Header id="title" className="text-center font-weight-bold">
                                ¡AHORCADO!
                            </Card.Header>
                            
                            <Card.Body>

                            <div className="d-flex justify-content-center">
                                <Image
                                    src={this.state.imagenes[this.state.cantIntentos]}
                                    rounded />
                            </div>

                            <Card.Title className="text-center font-weight-bold mt-3">
                                {this.state.modelo}
                            </Card.Title>

                            <div className="d-flex justify-content-center">
                                <div className="w-75">
                                    {this.generarTablero()}
                                </div>
                            </div>

                            </Card.Body>
                        </Card>
                    </div>
                </div> 
            </React.Fragment>)
        }
    }

export default App;