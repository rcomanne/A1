using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShowingController : Controller
    {
        private IRepository repo;

        private IPriceCalculator priceCalculator;

        public ShowingController(IRepository repo, IPriceCalculator priceCalculator)
        {
            this.repo = repo;
            this.priceCalculator = priceCalculator;
        }

        public ViewResult Index()
        {
            IEnumerable<Showing> showings = repo.Get<Showing>(s => s.Start >= DateTime.Now, q => q.OrderBy(s => s.Start));

            ViewBag.PriceCalculator = priceCalculator;

            return View(showings);
        }

        [HttpGet]
        public ActionResult Create() {
            List<string> movies = repo.GetAll<Movie>().Select(m => m.Name).Distinct().ToList();
            List<string> rooms = repo.GetAll<Room>().Select(r => r.Name).Distinct().ToList();

            ViewBag.Movies = movies;
            ViewBag.Rooms = rooms;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ShowingModel model) {
            if (ModelState.IsValid) {
                Showing showing = new Showing {
                    Start = model.Start,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    MovieId = repo.GetFirst<Movie>(m => m.Name.Equals(model.Movie)).Id, Is3D = model.Is3D,
                    RoomId = repo.GetFirst<Room>(m => m.Name.Equals(model.Room)).Id };
                repo.Create<Showing>(showing);
                return RedirectToAction("Index");
            }
            List<string> movies = repo.GetAll<Movie>().Select(m => m.Name).Distinct().ToList();
            List<string> rooms = repo.GetAll<Room>().Select(r => r.Name).Distinct().ToList();

            ViewBag.Movies = movies;
            ViewBag.Rooms = rooms;
            return View();
        }
    }
}