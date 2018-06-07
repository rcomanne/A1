using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System.Web.Mvc;
using Moq;
using WebUI.Controllers;

namespace CinemaTicketSystem.WebUI.Controllers.Tests {
    [TestClass()]
    public class OrdersControllerTest {
        [TestMethod()]
        public void DetailsTest() {
            // Setup
            Mock<IRepository> mock = new Mock<IRepository>();
            Showing initialShowing = new Showing() {
                Id = 1,
                Start = DateTime.Today,
                Movie = new Movie { Id = 1, Name = "Deadpool 2", YearOfRelease = 2018, LengthInMinutes = 120, SpokenLanguage = "English", Genre = "Actie/Avontuur", MinimumAge = 16, ImageUrl = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/Deadpool-2_ps_1_jpg_sd-high.jpg&alt=img/movie_placeholder.png" },
                Room = new Room { Id = 1, Name = "1", LocationId = 1 }
            };
            Order initialOrder = new Order {
                Id = 2,
                OrderNumber = 0000000002,
                Showing = initialShowing,
                NumberOfTickets = 4,
                TotalPrice = 34.0
            };
            mock.Setup(m => m.GetById<Order>(1)).Returns(initialOrder);

            OrderController controller = new OrderController(mock.Object, new Mock<IMailer>().Object, new Mock<IPriceCalculator>().Object);

            ActionResult actionResult = controller.Details(1);
            
            Order order = (Order)((Rotativa.ViewAsPdf)actionResult).Model;
            Assert.AreEqual(initialOrder.Id, order.Id);
            Assert.AreEqual(initialOrder.OrderNumber, order.OrderNumber);
            Assert.AreEqual(initialOrder.TotalPrice, order.TotalPrice);
            Assert.AreEqual(initialOrder.NumberOfTickets, order.NumberOfTickets);

            Assert.AreEqual(initialShowing.Movie.Id, order.Showing.Movie.Id);
            Assert.AreEqual(initialShowing.Movie.Name, order.Showing.Movie.Name);
            Assert.AreEqual(initialShowing.Movie.LengthInMinutes, order.Showing.Movie.LengthInMinutes);
            Assert.AreEqual(initialShowing.Movie.Genre, order.Showing.Movie.Genre);
            Assert.AreEqual(initialShowing.Movie.SpokenLanguage, order.Showing.Movie.SpokenLanguage);

            Assert.AreEqual(initialShowing.Room.Id, order.Showing.Room.Id);
            Assert.AreEqual(initialShowing.Room.NumberOfSeats, order.Showing.Room.NumberOfSeats);
            Assert.AreEqual(initialShowing.Room.WheelchairAccesible, order.Showing.Room.WheelchairAccesible);
        }
    }
}