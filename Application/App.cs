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

        public bool ArriesgarLetra(string letra){
            
            if (!letra.All(char.IsLetter))
                throw new ArgumentException("- Solo letras");
            if (letra.Length != 1)
                throw new ArgumentOutOfRangeException(string.Empty, "- Ingresar solo una letra");
            
            char l = char.ToLower(char.Parse(letra));
            
            var letras = new List<char>();
            
            letras.AddRange(_juego.Palabra.ToLower());

            return letras.Exists(x => x == l);
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
    }
}
