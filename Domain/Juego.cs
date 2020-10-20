using System.Collections.Generic;

namespace Domain
{
    public class Juego
    {
        public string Usuario = "Pepe";
        public string Palabra = "automovil";
        public string Modelo = "_ _ _ _ _ _ _ _ _";
        public List<char> LetrasIngresadas = new List<char>();
        public int CantIntentos = 6;
        public int Puntaje = 0;
    }
}