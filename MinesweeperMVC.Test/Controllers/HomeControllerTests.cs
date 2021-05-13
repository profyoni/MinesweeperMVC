using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMVC.Controllers.Tests
{
    class MockDatabase: IDatabase
    {
        public List<User> Users { get; set; }
    }
    [TestClass()]
    public class HomeControllerTests
    {
        private HomeController homeController = new HomeController(null,
            new MockDatabase());

        [TestMethod()]
        public void HomeControllerTest()
        {
            // Arrange db to have values needed for test

            homeController.Game();
            homeController.Move(1,2);
            Assert.Equals(2, HomeController._mm.Board[4, 5]);
        }
    }
}