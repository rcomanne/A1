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
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ViewResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}