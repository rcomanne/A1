using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTicketSystem.TouchUI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            IEnumerable<Movie> movies = repo.GetAll<Movie>();

            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MovieDetails(int? Id) {

            return View();
        }
    }
}