import React, { Component } from 'react';
import { Card, Image } from 'react-bootstrap';
import ahorcado0 from "../../images/ahorcado0.png";
import ahorcado1 from "../../images/ahorcado1.png";
import ahorcado2 from "../../images/ahorcado2.png";
import ahorcado3 from "../../images/ahorcado3.png";
import ahorcado4 from "../../images/ahorcado4.png";
import ahorcado5 from "../../images/ahorcado5.png";
import ahorcado6 from "../../images/ahorcado6.png";
import Letra from "../letra/Letra";

class Ahorcado extends Component {
    
    constructor(props) {
        super(props);
        this.state = {
            vidas: 6,
            errores: 0,
            acertado: new Set([]),
            palabra: "automovil",
            imagenes: [ahorcado0, ahorcado1, ahorcado2, ahorcado3, ahorcado4, ahorcado5, ahorcado6]
        }
    }

    intentoLetra = e => {
        let letra = e.target.value;
        this.setState(st => ({
            acertado: st.acertado.add(letra),
            errores: st.errores + (st.palabra.includes(letra) ? 0 : 1)
        }))
    }

    palabraAdivinada() {
        return this.state.palabra.split("").map(letra => (this.state.acertado.has(letra) ? letra : " _ "));
    }

    generarBotones() {
        return "aeioubcdfghjklmnñpqrstvwxyz".split("").map((letra, index) => (
            <Letra letra={letra} />
        ));
    }

    handleArriesgarLetra = (letra) => {
        console.log(letra);
    }

    render(){
        const gameOver = this.state.errores >= this.state.vidas;
        const ganador = this.palabraAdivinada().join("") === this.state.palabra;
        let tablero = this.generarBotones();

        if(ganador) {
            tablero = "¡Acertaste!"
        }

        if(gameOver) {
            tablero = "¡Perdiste!"
        }

        return(
            <React.Fragment>
                <div className="d-flex justify-content-center">
                    <Card className="W-75">
                        
                        <Card.Header id="title" className="text-center font-weight-bold">
                            ¡AHORCADO!
                        </Card.Header>
                        <Card.Body>
                        
                        <div className="d-flex justify-content-center">
                            <Image
                                src={this.state.imagenes[this.state.errores]}
                                rounded />
                        </div>

                        <Card.Title className="text-center font-weight-bold">
                            {!gameOver ? this.palabraAdivinada() : this.state.palabra}
                        </Card.Title>
                        
                        <div className="d-flex justify-content-center">
                            <div className="w-75">
                                {tablero}
                            </div>
                        </div>

                        </Card.Body>
                    </Card>
                </div> 
            </React.Fragment>
        )
    }

    // render() {
    //     const gameOver = this.state.errores >= this.props.vidas;
    //     const ganador = this.palabraAdivinada().join("") === this.state.palabra;
    //     let tablero = this.generarBotones();

    //     if(ganador) {
    //         tablero = "¡Acertaste!"
    //     }

    //     if(gameOver) {
    //         tablero = "¡Perdiste!"
    //     }

    //     return(
    //         <div className="Ahorcado container">
    //            <h1 className='text-center'>Ahorcado</h1> 
    //            <div className="float-right">Errores: {this.state.errores} de {this.props.vidas}</div>
    //            <div className="text-center">
    //                <img src={this.props.imagenes[this.state.errores]} alt=""></img>
    //            </div>
    //            <div className="text-center">
    //               <p> Adivina la palabra: </p> 
    //            </div>
    //            <p>
    //                {!gameOver ? this.palabraAdivinada() : this.state.palabra}
    //            </p>
    //             <p>{tablero}</p>

    //         </div>
    //     )
    // }    
}

export default Ahorcado;