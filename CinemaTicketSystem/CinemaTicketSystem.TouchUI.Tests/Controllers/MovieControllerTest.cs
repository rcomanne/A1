using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.TouchUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CinemaTicketSystem.TouchUI.Tests.Controllers
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void Index()
        {
            return;
            // Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Get<Showing>()).Returns(new List<Showing>()
            {
                new Showing() { Id = 1, Start = DateTime.Today },
                new Showing() { Id = 2, Start = DateTime.Now.AddMinutes(15) },
                new Showing() { Id = 3, Start = DateTime.Now.AddMinutes(10) },
                new Showing() { Id = 4, Start = DateTime.Today.AddDays(1) },
            });
            MovieController controller = new MovieController(mock.Object);

            // Act
            Showing[] result = ((IEnumerable<Showing>)controller.Index().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(3, result[0].Id);
            Assert.AreEqual(2, result[1].Id);
        }
    }
}
