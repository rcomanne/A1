using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSystem.Domain.Concrete;
using CinemaTicketSystem.Domain.Entities;

namespace WebUI.Views
{
    public class MapController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Map
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }


    }
}
