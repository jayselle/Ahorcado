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
        public bool Win { get; set; }
        public List<LetraIngresada> LetrasIngresadas { get; set; }
        public class LetraIngresada
        {
            public string Letra { get; set; }
        }
    }

    public class ValidationResponse
    {
        public bool Error { get; set; }
        public string Mensaje {get; set;}
    }

    public class SetJuegoResponse
    {
        public int Puntaje { get; set; }
        public string Modelo { get; set; }
        public int  CantIntentos { get; set; }
        public bool Win { get; set; }
        public bool Coincidencia { get; set; }
    }
}
