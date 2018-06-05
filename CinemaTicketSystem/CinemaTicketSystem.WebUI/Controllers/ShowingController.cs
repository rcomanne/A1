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
    }
}