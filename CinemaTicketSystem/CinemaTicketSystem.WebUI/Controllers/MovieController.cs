using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MovieController : Controller
    {
        protected IRepository repo;
        protected IPriceCalculator priceCalculator;

        public MovieController(IRepository repo, IPriceCalculator priceCalculator)
        {
            this.repo = repo;
            this.priceCalculator = priceCalculator;
        }

        public ViewResult Index()
        {
            IEnumerable<Movie> movies = repo.GetAll<Movie>(q => q.OrderBy(m => m.Name));

            return View(movies);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            Movie movie = repo.GetById<Movie>(id);
            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            var now = DateTime.Now;
            IEnumerable<Showing> showings = movie.Showings.Where(s => s.Start > now).OrderBy(s => s.Start);

            ViewBag.PriceCalculator = priceCalculator;

            return View(new MovieDetails { Movie = movie, Showings = showings });
        }
    }
}