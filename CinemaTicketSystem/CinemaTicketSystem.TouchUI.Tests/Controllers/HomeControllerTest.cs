using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaTicketSystem.TouchUI;
using CinemaTicketSystem.TouchUI.Controllers;
using CinemaTicketSystem.Domain.Abstract;
using Moq;
using CinemaTicketSystem.Domain.Entities;

namespace CinemaTicketSystem.TouchUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.GetAll<Movie>(null, null, null, null)).Returns(new List<Movie>()
            {
                new Movie() {Name = "Movie1"},
                new Movie() {Name = "Movie2"},
                new Movie() {Name = "Movie3"},
            });
            HomeController controller = new HomeController(mock.Object);

            // Act
            Movie[] result = ((IEnumerable<Movie>)controller.Index().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Movie1", result[0].Name);
            Assert.AreEqual("Movie2", result[1].Name);
            Assert.AreEqual("Movie3", result[2].Name);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
