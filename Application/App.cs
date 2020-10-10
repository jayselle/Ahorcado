using Domain;

namespace Application
{
    public class App
    {
        private Juego _juego;
        
        public App(){
            _juego = new Juego();
        }

        public bool ArriesgarPalabra(string palabra){
            return (_juego.Palabra == palabra);
        }
    }
}
