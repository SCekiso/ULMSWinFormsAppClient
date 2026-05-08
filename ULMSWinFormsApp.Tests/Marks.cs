using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ULMSWinFormsApp.Tests
{
    [TestClass]
    public class MarksTests
    {
        [TestMethod]
        public void AverageCalculation_ShouldReturnCorrectAverage()
        {
            // Arrange
            double sub1 = 60;
            double sub2 = 60;
            double sub3 = 60;

            // Act
            double average = (sub1 + sub2 + sub3) / 3;

            // Assert
            Assert.AreEqual(60, average);
        }
    }
}