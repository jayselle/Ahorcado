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
            
            while (true)
            {
                System.Console.WriteLine("Ingrese una letra");
                var input = System.Console.ReadLine();
                
                if (input == "exit")
                    break;

                try
                {
                    if (app.ArriesgarLetra(input)){
                        System.Console.WriteLine("¡Acertaste! :-)");
                        app.SaveModelo(input);
                    }
                    else
                        System.Console.WriteLine("¡No Acertaste! :-(");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }

                string modelo = app.GetModelo();

                System.Console.WriteLine(modelo);

                if (!modelo.Any(c => Char.ToString(c) == "_")){
                    System.Console.WriteLine("¡Ganaste "+app.GetUsuario()+"!");
                    break;
                }
            }
        }
    }
}
