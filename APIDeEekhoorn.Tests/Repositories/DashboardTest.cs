using System;
using APIDeEekhoorn.Logic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIDeEekhoorn.Tests.Repositories
{
    [TestClass]
    public class DashboardTest
    {
        [TestMethod]
        public void AmountPerMonthList()
        {
            // Arrange
            var rep = new DashboardRepository();

            // Act
            var result = rep.QuantityPerMonthListByDebcode("000503");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
