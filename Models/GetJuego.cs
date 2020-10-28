﻿using System.Collections.Generic;

namespace Models
{
    public class GetJuegoRespuesta
    {
        public string Modelo { get; set; }
        public int CantIntentos { get; set; }
		public int Puntaje { get; set; }
		public bool Coincidencia { get; set; }
        public List<LetraIngresada> LetrasIngresadas { get; set; }
        public class LetraIngresada
        {
            public int Id { get; set; }
            public string Letra { get; set; }
        }
    }
}