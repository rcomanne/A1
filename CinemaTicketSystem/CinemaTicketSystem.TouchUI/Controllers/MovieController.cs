using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTicketSystem.TouchUI.Controllers
{
    public class MovieController : Controller
    {
        private IRepository repo;

        public MovieController(IRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult GetMovieDetails() {

            return View();
        }
    }
}