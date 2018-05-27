using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ShowingController : Controller
    {
        private IRepository repo;

        public ShowingController(IRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            IEnumerable<Showing> showings = repo.Get<Showing>(s => s.Start >= DateTime.Now, q => q.OrderBy(s => s.Start));
            return View(showings);
        }
    }
}