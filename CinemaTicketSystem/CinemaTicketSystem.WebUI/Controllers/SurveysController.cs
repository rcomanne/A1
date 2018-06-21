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
using WebUI.Models;

namespace WebUI.Controllers
{
    public class SurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Surveys
        [HttpGet]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index() {
            SurveyStatisticsViewModel statistics = SurveyStatisticsViewModel.ToStatistics(db.Surveys.ToList());


            ViewBag.Comments = statistics.Comments;
            ViewBag.Results = statistics.GetNumbers();
            
            return View();
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OverallExperience,MovieExperience,TravelExperience,BathroomExperience,ShopExperience,FoodExperience,StaffExperience,Comment,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return View("../Showing/Index");
            }

            return View(survey);
        }
    }
}
