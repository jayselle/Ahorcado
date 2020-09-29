using System.Linq;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PalabraTests
    {
        [TestMethod]
        public void Test_Palabra_Sin_Numeros()
        {
            // Arrange
            Juego juego = new Juego();

            // Act
            var answer = !juego.Palabra.Any(char.IsDigit);
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Palabra_Con_Letras()
        {
            // Arrange
            Juego juego = new Juego();

            // Act
            var answer = juego.Palabra.All(char.IsLetter);
 
            // Assert
            Assert.IsTrue(answer);
        }

        [TestMethod]
        public void Test_Palabra_Longitud()
        {
            // Arrange
            Juego juego = new Juego();

            // Act and Assert
            Assert.AreEqual(juego.Palabra.Length, 4);
        }

        [TestMethod]
        public void Test_Palabra_Sin_Espacios()
        {
            // Arrange
            Juego juego = new Juego();

            // Act
            var answer = !juego.Palabra.Any(c=> c.Equals(" "));
 
            // Assert
            Assert.IsTrue(answer);
        }
    }
}