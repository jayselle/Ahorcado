using System.Collections.Generic;

namespace Models
{
    public class GetJuegoPedido
    {
        public string letra { get; set; }
    }

    public class GetJuegoRespuesta
    {
        public string Modelo { get; set; }
        public int CantIntentos { get; set; }
		public int Puntaje { get; set; }
		public bool Coincidencia { get; set; }
        public List<LetraIngresada> LetrasIngresadas { get; set; }
        public class LetraIngresada
        {
            public string Letra { get; set; }
        }
    }
}
