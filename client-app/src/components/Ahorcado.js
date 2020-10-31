import React, { Component } from 'react';
import './Ahorcado.css';
import ahorcado0 from "./imagenes/ahorcado0.png";
import ahorcado1 from "./imagenes/ahorcado1.png";
import ahorcado2 from "./imagenes/ahorcado2.png";
import ahorcado3 from "./imagenes/ahorcado3.png";
import ahorcado4 from "./imagenes/ahorcado4.png";
import ahorcado5 from "./imagenes/ahorcado5.png";
import ahorcado6 from "./imagenes/ahorcado6.png";


class Ahorcado extends Component {
    
    static defaultProps = {
        vidas: 6,
        imagenes: [ahorcado0, ahorcado1, ahorcado2, ahorcado3, ahorcado4, ahorcado5, ahorcado6]
    }

    constructor(props) {
        super(props);
        this.state = {
            errores: 0,
            acertado: new Set([]),
            palabra: "automovil"
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
        return "aeioubcdfghjklmnñpqrstvwxyz".split("").map(letra => (
            <button class="btn btn-lg btn-primary m-2"
            key={letra}
            value={letra}
            onClick={this.intentoLetra}
            disabled={this.state.acertado.has(letra)}
            >
                
                {letra}
            </button>
            

        ));
    }


    render() {
        const gameOver = this.state.errores >= this.props.vidas;
        const ganador = this.palabraAdivinada().join("") === this.state.palabra;
        let tablero = this.generarBotones();

        if(ganador) {
            tablero = "¡Acertaste!"
        }

        if(gameOver) {
            tablero = "¡Perdiste!"
        }

        return(
            <div className="Ahorcado container">
               <h1 className='text-center'>Ahorcado</h1> 
               <div className="float-right">Errores: {this.state.errores} de {this.props.vidas}</div>
               <div className="text-center">
                   <img src={this.props.imagenes[this.state.errores]} alt=""></img>
               </div>
               <div className="text-center">
                  <p> Adivina la palabra: </p> 
               </div>
               <p>
                   {!gameOver ? this.palabraAdivinada() : this.state.palabra}
               </p>
                <p>{tablero}</p>

            </div>
        )
    }    
}

export default Ahorcado;