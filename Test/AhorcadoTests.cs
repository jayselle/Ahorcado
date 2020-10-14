using System;
using System.Linq;
using System.Collections.Generic;
using Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class JuegoTests
    {
        [TestMethod]
        public void Test_Palabra_Ingresada_Sin_Numeros()
        {
            // Arrange
            string palabraIngresada = "auto";

            // Act
            var answer = !palabraIngresada.Any(char.IsDigit);
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Palabra_Ingresada_Con_Letras()
        {
            // Arrange
            string palabraIngresada = "auto";

            // Act
            var answer = palabraIngresada.All(char.IsLetter);
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Palabra_Ingresada_Longitud()
        {
            // Arrange
            string palabraIngresada = "auto";

            // Act and Assert
            Assert.AreEqual(palabraIngresada.Length, 4);
        }

        [TestMethod]
        public void Test_Palabra_Ingresada_Sin_Espacios()
        {
            // Arrange
            string palabraIngresada = "auto";

            // Act
            var answer = !palabraIngresada.Any(c=> c.Equals(" "));
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Palabra_Ingresada_Distinta_A_La_Hardcodeada()
        {
            // Arrange
            App app = new App();
            string palabraIngresada = "moto";

            // Act
            var answer = app.ArriesgarPalabra(palabraIngresada);
 
            // Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void Test_Palabra_Ingresada_Igual_A_La_Hardcodeada()
        {
            // Arrange
            App app = new App();
            string palabraIngresada = "automovil";

            // Act
            var answer = app.ArriesgarPalabra(palabraIngresada);

            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Solo letras")]
        public void Test_Arriesgar_Letra_Pero_Es_Cualquier_Cosa_Menos_Una_Letra()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "*";

            // Act
            var answer = app.ArriesgarLetra(letraIngresada);
 
            // Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Ingresar solo una letra")]
        public void Test_Arriesgar_Letra_Pero_Son_Muchas_Letras()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "muchasletras";

            // Act
            var answer = app.ArriesgarLetra(letraIngresada);
 
            // Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void Test_Arriesgar_Letra_Que_No_Esta()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "e";

            // Act
            var answer = app.ArriesgarLetra(letraIngresada);
 
            // Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void Test_Arriesgar_Letra_Que_Si_Esta()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "o";

            // Act
            var answer = app.ArriesgarLetra(letraIngresada);
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_No_Esta()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "b";

            // Act
            app.SaveModelo(letraIngresada);
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "_ _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_Si_Esta()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "a";

            // Act
            app.SaveModelo(letraIngresada);
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "A _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Sin_Aciertos_Previos_Con_Letra_Que_Esta_Repetida()
        {
            // Arrange
            App app = new App();
            string letraIngresada = "o";

            // Act
            app.SaveModelo(letraIngresada);
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "_ _ _ O _ O _ _ _");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Despues_De_Ingresar_Letras_Que_No_Coinciden()
        {
            // Arrange
            App app = new App();
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("p");
            letrasIngresadas.Add("r");
            letrasIngresadas.Add("K");
            letrasIngresadas.Add("e");

            // Act
            foreach (var letraIngresada in letrasIngresadas)
            {
                app.SaveModelo(letraIngresada);
            }
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "_ _ _ _ _ _ _ _ _");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Despues_De_Ingresar_Las_Letras_D_O_Q_L()
        {
            // Arrange
            App app = new App();
            var letrasIngresadas = new List<string>();
            letrasIngresadas.Add("d");
            letrasIngresadas.Add("o");
            letrasIngresadas.Add("q");
            letrasIngresadas.Add("L");

            // Act
            foreach (var letraIngresada in letrasIngresadas)
            {
                app.SaveModelo(letraIngresada);
            }
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "_ _ _ O _ O _ _ L");
        }

        [TestMethod]
        public void Test_Modelo_Ahorcado_Completo_Despues_De_Ingresar_Letras_Que_Si_Coinciden()
        {
            // Arrange
            App app = new App();
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
                app.SaveModelo(letraIngresada);
            }
            string modelo = app.GetModelo();
 
            // Assert
            Assert.AreEqual(modelo, "A U T O M O V I L");
        }
    }
}