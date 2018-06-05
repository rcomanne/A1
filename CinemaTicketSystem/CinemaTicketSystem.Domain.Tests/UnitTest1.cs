using System;
using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.Domain.Concrete;
using CinemaTicketSystem.Domain.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaTicketSystem.Domain.Tests
{
    [TestClass]
    public class PriceCalculatorTest
    {
        [TestMethod]
        public void TestShortMovie()
        {
            Movie movie = new Movie() { LengthInMinutes = 120 };
            Showing showing = new Showing() { Movie = movie };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing);

            Assert.AreEqual(8.5, price);
        }

        [TestMethod]
        public void TestLongMovie()
        {
            Movie movie = new Movie() { LengthInMinutes = 121 };
            Showing showing = new Showing() { Movie = movie };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing);

            Assert.AreEqual(9, price);
        }

        [TestMethod]
        public void TestChildEvening()
        {
            Movie movie = new Movie() { LengthInMinutes = 120, SpokenLanguage = "Dutch" };
            Showing showing = new Showing() { Movie = movie, Start = DateTime.Now.AddHours(20 - DateTime.Now.Hour) };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing, true);

            Assert.AreEqual(8.5, price);
        }

        [TestMethod]
        public void TestChildAdult()
        {
            Movie movie = new Movie() { LengthInMinutes = 120, SpokenLanguage = "Dutch" };
            Showing showing = new Showing() { Movie = movie, Start = DateTime.Now.AddHours(12 - DateTime.Now.Hour) };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing, false);

            Assert.AreEqual(8.5, price);
        }

        [TestMethod]
        public void TestChildEnglish()
        {
            Movie movie = new Movie() { LengthInMinutes = 120, SpokenLanguage = "English" };
            Showing showing = new Showing() { Movie = movie, Start = DateTime.Now.AddHours(12 - DateTime.Now.Hour) };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing, true);

            Assert.AreEqual(8.5, price);
        }

        [TestMethod]
        public void TestChild()
        {
            Movie movie = new Movie() { LengthInMinutes = 120, SpokenLanguage = "Dutch" };
            Showing showing = new Showing() { Movie = movie, Start = DateTime.Now.AddHours(12 - DateTime.Now.Hour) };
            IPriceCalculator PriceCalculator = new PriceCalculator();

            var price = PriceCalculator.CalculatePrice(showing, true);

            Assert.AreEqual(7.0, price);
        }
    }
}
