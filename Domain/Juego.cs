using System.Collections.Generic;

namespace Domain
{
    public class Juego
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Palabra { get; set; }
        public string Modelo { get; set; }
        public int CantIntentos { get; set; }
        public int Puntaje { get; set; }
        public List<LetraIngresada> LetrasIngresadas { get; set; }
    }
}