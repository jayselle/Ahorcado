using System;
using System.Linq;
using System.Collections.Generic;
using Domain;
using Persistence;
using Models;
using System.Threading.Tasks;

namespace Application
{
    public class App
    {
        private readonly DataContext _context;

        public App(DataContext context){
            _context = context;
        }

        #region Palabra
        public async Task<GetJuegoRespuesta> GetModelo(){
            
            var juego = await _context.Juegos.FindAsync(1);

            var letrasIngresadas = _context.LetraIngresadas.Where(x => x.Juego.Id == 1).ToList();

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = juego.Modelo,
                LetrasIngresadas = letrasIngresadas.Select(
                    x => new GetJuegoRespuesta.LetraIngresada { Letra = x.Letra }).ToList(),
                CantIntentos = juego.CantIntentos,
                Puntaje = juego.Puntaje,
                Coincidencia = false
            };

            return GetJuegoRespuesta;
        }

        public async Task<GetJuegoRespuesta> ArriesgarLetra(string letra){
            
            var juego = await _context.Juegos.FindAsync(1);

            var letrasIngresadas = _context.LetraIngresadas.Where(x => x.Juego.Id == 1).ToList();

            if (!letra.All(char.IsLetter))
                throw new Exception("Solo letras.");
            if (letra.Length != 1)
                throw new Exception("Ingresar solo una letra.");
            
            if (letrasIngresadas.Exists(x => x.Letra == letra)){
                 throw new Exception("Letra ya ingresada.");
            } else {
                var nuevaLetra = new LetraIngresada {
                    Letra = letra,
                    Juego = juego
                };

                letrasIngresadas.Add(nuevaLetra);
                _context.LetraIngresadas.Add(nuevaLetra);
            }

            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            var coincidencia = letras.Exists(x => x == char.ToLower(char.Parse(letra)));

            if (coincidencia) {
                juego.Puntaje += 100;
                juego.Modelo = this.GetNewModel(juego.Modelo, juego.Palabra, letra);
            } else {
                juego.Puntaje -= 100;
                juego.CantIntentos -= 1;
            }

            var success = await _context.SaveChangesAsync() > 0;

            if (!success)
                throw new Exception("Problem saving changes");

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = juego.Modelo,
                LetrasIngresadas = letrasIngresadas.Select(
                    x => new GetJuegoRespuesta.LetraIngresada { Letra = x.Letra }).ToList(),
                CantIntentos = juego.CantIntentos,
                Puntaje = juego.Puntaje,
                Coincidencia = coincidencia
            };

            return GetJuegoRespuesta;
        }
        #endregion

        #region Helpers
        public string GetNewModel(string modelo, string palabra, string letra){

            char l = char.ToLower(char.Parse(letra));
                        
            var p = new List<char>();

            p.AddRange(palabra.ToLower());

            var modeloSinEspacios = new List<char>();

            modeloSinEspacios.AddRange(modelo.Replace(" ",""));

            for (int i = 0; i < p.Count; i++){
                if (p[i] == l)
                    modeloSinEspacios[i] = char.ToUpper(l);
            }

            string str = "";

            for (int i = 0; i < modeloSinEspacios.Count; i++){
                if (i == modeloSinEspacios.Count - 1)
                    str += modeloSinEspacios[i];
                else
                    str += modeloSinEspacios[i] + " ";
            }

            return str;
        }
        #endregion
    }
}
