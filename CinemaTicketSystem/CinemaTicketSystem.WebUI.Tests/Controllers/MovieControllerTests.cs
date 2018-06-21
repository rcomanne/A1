using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTicketSystem.Domain.Abstract;
using Moq;
using CinemaTicketSystem.Domain.Entities;
using System.Web.Mvc;
using CinemaTicketSystem.WebUI.Models;

namespace WebUI.Controllers.Tests {
    [TestClass()]
    public class MovieControllerTests {
        [TestMethod()]
        public void CreateTest() {
            Mock<IRepository> repoMock = new Mock<IRepository>();
            Mock<IPriceCalculator> calculatorMock = new Mock<IPriceCalculator>();
            MovieController movieController = new MovieController(repoMock.Object, calculatorMock.Object);
            ICollection<Showing> showings = new HashSet<Showing>();
            showings.Add(new Showing { Id = 1, MovieId = 1, RoomId = 1 });
            Movie movie = new Movie {
                Id = 1,
                Name = "TestFilm",
                Director = "Tester",
                Genre = "Test",
                ImageUrl = "image.url.com",
                Imdb = "imdb.url.com",
                Is3D = true,
                SpokenLanguage = "Nederlands",
                SubtitleLanguage = "Nederlands, slechthorend",
                LengthInMinutes = 123,
                YearOfRelease = 2018,
                Trailer = "trailer.url.com",
                MinimumAge = 12,
                ShortDescription = "Test film description",
                LastShowDate = DateTime.Now.AddYears(1),
                Showings = showings
            };

            ViewResult result = (ViewResult)movieController.Create(movie);

            MovieDetails savedDetails = (MovieDetails)result.Model;

            Movie savedMovie = savedDetails.Movie;

            Assert.IsNotNull(savedMovie);
            Assert.AreEqual(movie.Name, savedMovie.Name);
            Assert.AreEqual(movie.Director, savedMovie.Director);
            Assert.AreEqual(movie.Genre, savedMovie.Genre);
            Assert.AreEqual(movie.ImageUrl, savedMovie.ImageUrl);
            Assert.AreEqual(movie.Imdb, savedMovie.Imdb);
            Assert.AreEqual(movie.Is3D, savedMovie.Is3D);
            Assert.AreEqual(movie.SpokenLanguage, savedMovie.SpokenLanguage);
            Assert.AreEqual(movie.SubtitleLanguage, savedMovie.SubtitleLanguage);
            Assert.AreEqual(movie.LengthInMinutes, savedMovie.LengthInMinutes);
            Assert.AreEqual(movie.YearOfRelease, savedMovie.YearOfRelease);
            Assert.AreEqual(movie.Trailer, savedMovie.Trailer);
            Assert.AreEqual(movie.MinimumAge, savedMovie.MinimumAge);
            Assert.AreEqual(movie.ShortDescription, savedMovie.ShortDescription);
            Assert.AreEqual(movie.LastShowDate, savedMovie.LastShowDate);

            List<Showing> savedShowings = savedMovie.Showings.ToList();
            Assert.IsNotNull(savedShowings);
            Assert.AreEqual(1, savedShowings.Count());
            Assert.AreEqual(1, savedShowings.First<Showing>().MovieId);
            Assert.AreEqual(1, savedShowings.First<Showing>().RoomId);
        }
    }
}