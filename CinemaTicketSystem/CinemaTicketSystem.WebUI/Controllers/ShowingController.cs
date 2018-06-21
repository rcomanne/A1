using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Concrete;
using CinemaTicketSystem.Domain.Entities;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.UserManagement;

namespace WebUI.Controllers
{
    public class ShowingController : Controller
    {
        private IRepository repo;

        private ApplicationDbContext db = new ApplicationDbContext();

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
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showing showing = repo.GetById<Showing>(id);
            if (showing.Movie == null) {
                showing.Movie = repo.GetById<Movie>(showing.MovieId);
            }
            if (showing.Room == null) {
                showing.Room = repo.GetById<Room>(showing.RoomId);
            }
            
            return View(showing);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create() {
            List<string> movies = repo.GetAll<Movie>().Select(m => m.Name).Distinct().ToList();
            List<int> rooms = repo.GetAll<Room>().Select(r => r.Id).Distinct().ToList();

            ViewBag.Movies = movies;
            ViewBag.Rooms = rooms;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create(ShowingModel model) {
            if (ModelState.IsValid) {
                DateTime now = DateTime.Now;
                Showing showing = new Showing {
                    Start = model.Start.ToLocalTime(),
                    CreatedDate = now,
                    ModifiedDate = new DateTime(),
                    CreatedBy = "Admin",
                    ModifiedBy = "Admin",
                    MovieId = repo.GetFirst<Movie>(m => m.Name.Equals(model.Movie)).Id,
                    Is3D = model.Is3D,
                    RoomId = repo.GetFirst<Room>(r => r.Id.Equals(model.Room)).Id
                };
                if (showing.Movie == null) {
                    showing.Movie = repo.GetById<Movie>(showing.MovieId);
                }
                if (showing.Room == null) {
                    showing.Room = repo.GetById<Room>(showing.RoomId);
                }
                
                repo.Create<Showing>(showing);
                repo.Save();
                return View("~/Views/Showing/Details.cshtml", showing);
            }
            List<string> movies = repo.GetAll<Movie>().Select(m => m.Name).Distinct().ToList();
            List<int> rooms = repo.GetAll<Room>().Select(r => r.Id).Distinct().ToList();

            ViewBag.Movies = movies;
            ViewBag.Rooms = rooms;
            return View();
        }
    }
}