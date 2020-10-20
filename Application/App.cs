using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Application
{
    public class App
    {
        private Juego _juego;
        
        public App(){
            _juego = new Juego();
        }

        #region Palabra
        public bool ArriesgarPalabra(string palabra){
            return (_juego.Palabra == palabra);
        }

        public GetJuegoRespuesta ArriesgarLetra(string letra){
            
            var letrasIngresadas = _juego.LetrasIngresadas;

            if (!letra.All(char.IsLetter))
                throw new ArgumentException("- Solo letras");
            if (letra.Length != 1)
                throw new ArgumentOutOfRangeException(string.Empty, "- Ingresar solo una letra");

            char l = char.ToLower(char.Parse(letra));
            
            if (letrasIngresadas.Exists(x => x == l))
                throw new ArgumentException("- Letra ya ingresada. " + this.GetLetrasIngresadas());
            else
               letrasIngresadas.Add(l); 
            
            var letras = new List<char>();
            
            letras.AddRange(_juego.Palabra.ToLower());

            var coincidencia = letras.Exists(x => x == l);

            this.SavePuntaje(coincidencia);

            if (coincidencia)
                this.SaveModelo(letra);
            else
                this.RestarIntento();

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = this.GetModelo(),
                LetrasIngresadas = this.GetLetrasIngresadas(),
                CantIntentos = this.GetIntentos(),
                Puntaje = this.GetPuntaje(),
                Coincidencia = coincidencia
            };

            return GetJuegoRespuesta;
        }
        #endregion

        #region Modelo
        public string GetModelo(){
            return _juego.Modelo;
        }

        public void SaveModelo(string letra){

            char l = char.ToLower(char.Parse(letra));
            
            var palabra = new List<char>();
            
            palabra.AddRange(_juego.Palabra.ToLower());
            
            var modeloSinEspacios = new List<char>();
            
            modeloSinEspacios.AddRange(_juego.Modelo.Replace(" ",""));

            for (int i = 0; i < palabra.Count; i++){
                if (palabra[i] == l)
                    modeloSinEspacios[i] = char.ToUpper(l);
            }

            string str = "";

            for (int i = 0; i < modeloSinEspacios.Count; i++){
                if (i == modeloSinEspacios.Count - 1)
                    str += modeloSinEspacios[i];
                else
                    str += modeloSinEspacios[i] + " ";
            }

            _juego.Modelo = str;
        }
        #endregion

        #region Usuario
        public string GetUsuario(){
            return _juego.Usuario;
        }
        #endregion

        #region Intentos
        public int GetIntentos(){
            return _juego.CantIntentos;
        }

        public void RestarIntento(){
            _juego.CantIntentos = _juego.CantIntentos - 1;
        }
        #endregion

        #region Score
        public int GetPuntaje(){
            return _juego.Puntaje;
        }

        public void SavePuntaje(bool coincidencia){
            if (coincidencia)
                _juego.Puntaje += 100;
            else
                _juego.Puntaje -= 10;
        }
        #endregion

        #region Helpers
        public string GetLetrasIngresadas(){
            string letras = "";
            var letrasIngresadas = _juego.LetrasIngresadas;
            if (letrasIngresadas.Count > 0){
                foreach (var letra in letrasIngresadas)
                {
                    letras += letra + " ";
                }
            }
            return letras;
        }
        #endregion
    }
}
