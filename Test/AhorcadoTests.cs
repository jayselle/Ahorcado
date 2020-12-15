using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test
{
    [TestClass]
    public class JuegoTests
    {
        [TestMethod]
        public void Test_Arriesgar_Letra_Que_No_Esta()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();
            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            juego.Palabra  = "automovil";
            letraIngresada.Letra = "e";

            // Act
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            bool coincidencia = letras.Exists(x => x == char.ToLower(char.Parse(letraIngresada.Letra)));

            // Assert
            Assert.IsFalse(coincidencia);
        }

        [TestMethod]
        public void Test_Arriesgar_Letra_Que_Si_Esta()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();
            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            juego.Palabra = "automovil";
            letraIngresada.Letra = "a";

            // Act
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            bool coincidencia = letras.Exists(x => x == char.ToLower(char.Parse(letraIngresada.Letra)));

            // Assert
            Assert.IsTrue(coincidencia);
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_No_Esta()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();
            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";
            letraIngresada.Letra = "b";

            // Act
            char l = char.ToLower(char.Parse(letraIngresada.Letra));
                        
            var p = new List<char>();

            p.AddRange(juego.Palabra.ToLower());

            var modeloSinEspacios = new List<char>();

            modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

            // Assert
            Assert.AreEqual(str, "_ _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_Si_Esta()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();
            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";
            letraIngresada.Letra = "a";

            // Act
            char l = char.ToLower(char.Parse(letraIngresada.Letra));
                        
            var p = new List<char>();

            p.AddRange(juego.Palabra.ToLower());

            var modeloSinEspacios = new List<char>();

            modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

            // Assert
            Assert.AreEqual(str, "A _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_Esta_Repetida()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();
            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";
            letraIngresada.Letra = "o";

            // Act
            char l = char.ToLower(char.Parse(letraIngresada.Letra));
                        
            var p = new List<char>();

            p.AddRange(juego.Palabra.ToLower());

            var modeloSinEspacios = new List<char>();

            modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

            // Assert
            Assert.AreEqual(str, "_ _ _ O _ O _ _ _");
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Despues_De_Ingresar_Letras_Que_No_Coinciden()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";

            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("p");
            letrasIngresadas.Add("r");
            letrasIngresadas.Add("K");
            letrasIngresadas.Add("e");
            
            // Act
            foreach (var letraIngresada in letrasIngresadas)
            {
                char l = char.ToLower(char.Parse(letraIngresada));
                        
                var p = new List<char>();

                p.AddRange(juego.Palabra.ToLower());

                var modeloSinEspacios = new List<char>();

                modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

                juego.Modelo = str;
            }
 
            // Assert
            Assert.AreEqual(juego.Modelo, "_ _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Despues_De_Ingresar_Las_Letras_D_O_Q_L()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("d");
            letrasIngresadas.Add("o");
            letrasIngresadas.Add("q");
            letrasIngresadas.Add("L");
            
            // Act
            foreach (var letraIngresada in letrasIngresadas)
            {
                char l = char.ToLower(char.Parse(letraIngresada));
                        
                var p = new List<char>();

                p.AddRange(juego.Palabra.ToLower());

                var modeloSinEspacios = new List<char>();

                modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

                juego.Modelo = str;
            }
 
            // Assert
            Assert.AreEqual(juego.Modelo, "_ _ _ O _ O _ _ L");
        }

        [TestMethod]
        public void Test_Metodo_GetNewModel_Modelo_Ahorcado_Completo_Despues_De_Ingresar_Letras_Que_Si_Coinciden()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.Palabra = "automovil";
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("l");
            letrasIngresadas.Add("U");
            letrasIngresadas.Add("T");
            letrasIngresadas.Add("m");
            letrasIngresadas.Add("a");
            letrasIngresadas.Add("o");
            letrasIngresadas.Add("v");
            letrasIngresadas.Add("i");
            
            // Act
            foreach (var letraIngresada in letrasIngresadas)
            {
                char l = char.ToLower(char.Parse(letraIngresada));
                        
                var p = new List<char>();

                p.AddRange(juego.Palabra.ToLower());

                var modeloSinEspacios = new List<char>();

                modeloSinEspacios.AddRange(juego.Modelo.Replace(" ",""));

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

                juego.Modelo = str;
            }
 
            // Assert
            Assert.AreEqual(juego.Modelo, "A U T O M O V I L");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Juego_Perdido_Con_Seis_Intentos_Fallidos()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Palabra = "automovil";
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("s");
            letrasIngresadas.Add("Y");
            letrasIngresadas.Add("b");
            letrasIngresadas.Add("c");
            letrasIngresadas.Add("R");
            letrasIngresadas.Add("K");
            juego.CantIntentos = 6;

            // Act
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            foreach (var letraIngresada in letrasIngresadas)
            {
                if (!letras.Exists(x => x == char.ToLower(char.Parse(letraIngresada))))
                    juego.CantIntentos = juego.CantIntentos - 1;
            }

            // Assert
            Assert.AreEqual(juego.CantIntentos, 0);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Puntaje_Con_Todos_Los_Intentos_Fallidos()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Palabra = "automovil";
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("s");
            letrasIngresadas.Add("Y");
            letrasIngresadas.Add("b");
            letrasIngresadas.Add("c");
            letrasIngresadas.Add("R");
            letrasIngresadas.Add("K");
            juego.Puntaje = 0;
            
            // Act
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            foreach (var letraIngresada in letrasIngresadas)
            {
                if (!letras.Exists(x => x == char.ToLower(char.Parse(letraIngresada))))
                    juego.Puntaje = juego.Puntaje - 10;
            }
 
            // Assert
            Assert.AreEqual(juego.Puntaje, -60);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Puntaje_Con_Todos_Los_Intentos_Acertados()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Palabra = "automovil";
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("l");
            letrasIngresadas.Add("U");
            letrasIngresadas.Add("T");
            letrasIngresadas.Add("m");
            letrasIngresadas.Add("a");
            letrasIngresadas.Add("o");
            letrasIngresadas.Add("v");
            letrasIngresadas.Add("i");
            juego.Puntaje = 0;
            
             // Act
            var letras = new List<char>();
            
            letras.AddRange(juego.Palabra.ToLower());

            foreach (var letraIngresada in letrasIngresadas)
            {
                if (letras.Exists(x => x == char.ToLower(char.Parse(letraIngresada))))
                    juego.Puntaje = juego.Puntaje + 100;
            }
 
            // Assert
            Assert.AreEqual(juego.Puntaje, 800);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Juego_Todavia_No_Ganado()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Modelo = "A _ T _ M _ _ _ _";
            juego.Win = false;

            // Act
            juego.Win = !juego.Modelo.Contains("_");
 
            // Assert
            Assert.IsFalse(juego.Win);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Juego_Ganado()
        {
            // Arrange
            Domain.Juego juego = new Domain.Juego();

            juego.Modelo = "A U T O M O V I L";
            juego.Win = false;

            // Act
            juego.Win = !juego.Modelo.Contains("_");
 
            // Assert
            Assert.IsTrue(juego.Win);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Helper_Modelo_Correcto()
        {
            // Arrange
            Application.App app = new Application.App(null);

            // Act
            string newModel = app.GetNewModel("_ _ _ _ _ _ _ _ _", "automovil", "a");
 
            // Assert
            Assert.AreEqual("A _ _ _ _ _ _ _ _", newModel);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Helper_Modelo_Incorrecto()
        {
            // Arrange
            Application.App app = new Application.App(null);

            // Act
            string newModel = app.GetNewModel("_ _ _ _ _ _ _ _ _", "automovil", "a");
 
            // Assert
            Assert.AreNotEqual("_ U _ _ _ _ _ _ _", newModel);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Validation_Letra_Correcta()
        {
            // Arrange
            Application.App app = new Application.App(null);
            string letra = "a";
            var letrasIngresadas = new List<LetraIngresada>();
            letrasIngresadas.Add(new LetraIngresada { Letra = "u", Juego = null });
            letrasIngresadas.Add(new LetraIngresada { Letra = "p", Juego = null });
            
            // Act
            var validationResponse = app.ValidateLetra(letra, letrasIngresadas);
 
            // Assert
            Assert.IsFalse(validationResponse.Error);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Validation_No_Es_Letra()
        {
            // Arrange
            Application.App app = new Application.App(null);
            string letra = "*";
            var letrasIngresadas = new List<LetraIngresada>();
            letrasIngresadas.Add(new LetraIngresada { Letra = "u", Juego = null });
            letrasIngresadas.Add(new LetraIngresada { Letra = "p", Juego = null });
            
            // Act
            var validationResponse = app.ValidateLetra(letra, letrasIngresadas);
 
            // Assert
            Assert.IsTrue(validationResponse.Error);
            Assert.AreEqual("Solo letras.", validationResponse.Mensaje);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Validation_Muchas_Letras()
        {
            // Arrange
            Application.App app = new Application.App(null);
            string letra = "bb";
            var letrasIngresadas = new List<LetraIngresada>();
            letrasIngresadas.Add(new LetraIngresada { Letra = "u", Juego = null });
            letrasIngresadas.Add(new LetraIngresada { Letra = "p", Juego = null });
            
            // Act
            var validationResponse = app.ValidateLetra(letra, letrasIngresadas);
 
            // Assert
            Assert.IsTrue(validationResponse.Error);
            Assert.AreEqual("Ingresar solo una letra.", validationResponse.Mensaje);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Validation_Letra_Ya_Ingresada()
        {
            // Arrange
            Application.App app = new Application.App(null);
            string letra = "a";
            var letrasIngresadas = new List<LetraIngresada>();
            letrasIngresadas.Add(new LetraIngresada { Letra = "t", Juego = null });
            letrasIngresadas.Add(new LetraIngresada { Letra = "a", Juego = null });
            
            // Act
            var validationResponse = app.ValidateLetra(letra, letrasIngresadas);
 
            // Assert
            Assert.IsTrue(validationResponse.Error);
            Assert.AreEqual("Letra ya ingresada.", validationResponse.Mensaje);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_SetJuego()
        {
            // Arrange
            Juego juego = new Juego();
            juego.Palabra = "automovil";
            juego.Modelo = "_ _ _ _ _ _ _ _ _";
            juego.CantIntentos = 6;
            juego.Puntaje = 0;
            juego.Win = false;
            Application.App app = new Application.App(null);

            // Act
            var setJuegoResponse = app.SetJuego(juego, "a");
 
            // Assert
            Assert.AreEqual(100, setJuegoResponse.Puntaje);
            Assert.AreEqual("A _ _ _ _ _ _ _ _", setJuegoResponse.Modelo);
            Assert.AreEqual(6, setJuegoResponse.CantIntentos);
            Assert.IsFalse(setJuegoResponse.Win);
            Assert.IsTrue(setJuegoResponse.Coincidencia);
        }
    }
}
