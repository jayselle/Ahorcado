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

        #region Juego
        public async Task<GetJuegoRespuesta> GetJuego(){
            
            var juego = await _context.Juegos.FindAsync(1);

            var letrasIngresadas = _context.LetraIngresadas.Where(x => x.Juego.Id == 1).ToList();

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = juego.Modelo,
                LetrasIngresadas = letrasIngresadas.Select(
                    x => new GetJuegoRespuesta.LetraIngresada { Letra = x.Letra }).ToList(),
                CantIntentos = juego.CantIntentos,
                Puntaje = juego.Puntaje,
                Coincidencia = false,
                Win = juego.Win
            };

            return GetJuegoRespuesta;
        }
        
        public async Task<GetJuegoRespuesta> ResetJuego()
        {
            var juego = await _context.Juegos.FindAsync(1);

            if (juego != null){
                juego.Id = 1;
                juego.Usuario = "Pepe";
                juego.Palabra = "automovil";
                juego.Modelo = "_ _ _ _ _ _ _ _ _";
                juego.CantIntentos = 6;
                juego.Puntaje = 0;
                juego.Win = false;
            }

            var letrasIngresadas = _context.LetraIngresadas.ToList();
            
            _context.LetraIngresadas.RemoveRange(letrasIngresadas);

            await _context.SaveChangesAsync();

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = juego.Modelo,
                LetrasIngresadas = null,
                CantIntentos = juego.CantIntentos,
                Puntaje = juego.Puntaje,
                Coincidencia = false,
                Win = juego.Win
            };

            return GetJuegoRespuesta;
        }
        #endregion

        #region Palabra
        public async Task<GetJuegoRespuesta> ArriesgarLetra(string letra){
            
            var juego = await _context.Juegos.FindAsync(1);

            var letrasIngresadas = _context.LetraIngresadas.Where(x => x.Juego.Id == 1).ToList();

            var validationResponse = ValidateLetra(letra, letrasIngresadas);

            if (validationResponse.Error)
                throw new Exception(validationResponse.Mensaje);
            
            var nuevaLetra = new LetraIngresada {
                Letra = letra,
                Juego = juego
            };

            letrasIngresadas.Add(nuevaLetra);
            _context.LetraIngresadas.Add(nuevaLetra);

            var setJuegoResponse = this.SetJuego(juego, letra);
            juego.Puntaje = setJuegoResponse.Puntaje;
            juego.Modelo = setJuegoResponse.Modelo;
            juego.CantIntentos = setJuegoResponse.CantIntentos;
            juego.Win = setJuegoResponse.Win;

            var success = await _context.SaveChangesAsync() > 0;

            if (!success)
                throw new Exception("Problem saving changes");

            var GetJuegoRespuesta = new GetJuegoRespuesta {
                Modelo = juego.Modelo,
                LetrasIngresadas = letrasIngresadas.Select(
                    x => new GetJuegoRespuesta.LetraIngresada { Letra = x.Letra }).ToList(),
                CantIntentos = juego.CantIntentos,
                Puntaje = juego.Puntaje,
                Coincidencia = setJuegoResponse.Coincidencia,
                Win = juego.Win
            };

            return GetJuegoRespuesta;
        }

        public ValidationResponse ValidateLetra(string letra, List<LetraIngresada> letrasIngresadas) {
            bool error = false;
            string mensaje = "";

            if (!letra.All(char.IsLetter)) {
                error = true;
                mensaje = "Solo letras.";
            } else if (letra.Length != 1) {
                error = true;
                mensaje = "Ingresar solo una letra.";
            } else if (letrasIngresadas.Exists(x => x.Letra == letra)) {
                error = true;
                mensaje = "Letra ya ingresada.";
            }

            return new ValidationResponse {
                Error = error,
                Mensaje = mensaje,
            };
        }

        public SetJuegoResponse SetJuego(Juego juego, string letra) {
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            var coincidencia = letras.Exists(x => x == char.ToLower(char.Parse(letra)));

            string newModelo = this.GetNewModel(juego.Modelo, juego.Palabra, letra);

            var response = new SetJuegoResponse {
                Puntaje = coincidencia ? (juego.Puntaje += 100) : (juego.Puntaje -= 10),
                Modelo = coincidencia ? newModelo : juego.Modelo,
                CantIntentos = coincidencia ? juego.CantIntentos : (juego.CantIntentos -= 1),
                Win = !newModelo.Contains("_"),
                Coincidencia = coincidencia
            };

            return response;
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
