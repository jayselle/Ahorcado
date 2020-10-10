using System.Linq;
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
            string palabraIngresada = "auto";

            // Act
            var answer = app.ArriesgarPalabra(palabraIngresada);

            // Assert
            Assert.IsTrue(answer);
        }
    }
}