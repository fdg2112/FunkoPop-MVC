using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Logic.Tests
{
    [TestClass()]
    public class ProductLogicTests
    {
        [TestMethod()]
        public void ProductLogicTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetOneTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            var productLogic = new ProductLogic();

            // Act
            List<Product> products = productLogic.GetAll();

            // Assert:
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListAdminTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReactivateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DiscountStockTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStockTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LinkImageWithProductTest()
        {
            Assert.Fail();
        }
    }
}