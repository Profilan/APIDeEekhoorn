using System;
using APIDeEekhoorn.Logic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIDeEekhoorn.Tests.Repositories
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetUserByUsername()
        {
            // Arrange
            var rep = new UserRepository();

            // Act
            var result = rep.GetByUsername("xxx");

            // Assert
            Assert.IsNull(result);
        }
    }
}
