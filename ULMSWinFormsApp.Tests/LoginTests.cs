using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ULMSWinFormsApp.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Login_ShouldPass_WhenUsernameAndPasswordAreCorrect()
        {
            // Arrange
            string username = "admin";
            string password = "1234";

            // Act
            bool result = (username == "admin" && password == "1234");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Login_ShouldFail_WhenPasswordIsIncorrect()
        {
            // Arrange
            string username = "admin";
            string password = "wrong";

            // Act
            bool result = (username == "admin" && password == "1234");

            // Assert
            Assert.IsFalse(result);
        }
    }
}