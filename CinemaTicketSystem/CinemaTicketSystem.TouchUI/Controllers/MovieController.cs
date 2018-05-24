using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Concrete;
using CinemaTicketSystem.Domain.Entities;

namespace CinemaTicketSystem.TouchUI.Controllers
{
    public class MovieController : Controller
    {
        private IRepository repo;

        public MovieController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(repo.GetAll<Movie>());
        }
    }
}
