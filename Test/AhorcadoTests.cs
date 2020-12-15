using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Persistence;
using Models;
using Application;

namespace Test
{
    [TestClass]
    public class JuegoTests
    {
        [TestMethod]
        public void Test_Arriesgar_Letra_Pero_Es_Cualquier_Cosa_Menos_Una_Letra()
        {
            // Arrange

            Domain.Juego juego = new Domain.Juego();

            juego.Palabra = "*";
            string errorMessage = "";
            
            // Act
            try{
                if (!juego.Palabra.Any(char.IsLetter))
                    throw new ArgumentException("Solo letras");
            } catch (ArgumentException e){
                errorMessage = e.Message;
            }

            // Assert
            Assert.AreEqual("Solo letras", errorMessage);
        }

        [TestMethod]
        public void Test_Arriesgar_Letra_Pero_Son_Muchas_Letras()
        {
            // Arrange

            Domain.LetraIngresada letraIngresada = new Domain.LetraIngresada();

            letraIngresada.Letra = "muchasletras";
            string errorMessage = "";

            // Act
            try{
                if (letraIngresada.Letra.Length != 1)
                    throw new ArgumentOutOfRangeException(string.Empty, "Ingresar solo una letra");
            } catch (ArgumentOutOfRangeException e){
                errorMessage = e.Message;
            }

            // Assert
            Assert.AreEqual("Ingresar solo una letra", errorMessage);
        }

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
    }
}
