using System;
using System.Linq;
using Application;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            System.Console.WriteLine("¡Bienvenido "+app.GetUsuario()+"! ¿Jugamos al Ahorcado?");
            System.Console.WriteLine(app.GetModelo());
            var respuesta = new GetJuegoRespuesta();
            
            while (true)
            {
                System.Console.WriteLine("Ingrese una letra");
                var input = System.Console.ReadLine();
                
                if (input == "exit")
                    break;

                try
                {
                    respuesta = app.ArriesgarLetra(input);
                    if (respuesta.Coincidencia)
                        System.Console.WriteLine("¡Acertaste! :-)");
                    else
                        System.Console.WriteLine("¡No Acertaste! :-(");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }

                string modelo = respuesta.Modelo;

                System.Console.WriteLine(respuesta.Modelo);

                System.Console.WriteLine("Puntaje: " + respuesta.Puntaje);

                if (!modelo.Any(c => Char.ToString(c) == "_")){
                    System.Console.WriteLine("¡Ganaste "+app.GetUsuario()+"!");
                    break;
                }

                int cantIntentos = respuesta.CantIntentos;
                
                System.Console.WriteLine("Te quedan " + cantIntentos + " intentos.");
                
                if (cantIntentos == 0){
                    System.Console.WriteLine("¡Perdiste "+app.GetUsuario()+"!");
                    break;
                }
            }
        }
    }
}
