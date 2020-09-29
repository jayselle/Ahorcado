using Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class JuegoTests
    {
        [TestMethod]
        public void Test_Palabra_Distinta()
        {
            // Arrange
            App app = new App();

            // Act
            var answer = app.Validar("moto");
 
            // Assert
            Assert.IsFalse(answer);
        }

        [TestMethod]
        public void Test_Palabra_Igual()
        {
            // Arrange
            App app = new App();

            // Act
            var answer = app.Validar("auto");

            // Assert
            Assert.IsTrue(answer);
        }
    }
}