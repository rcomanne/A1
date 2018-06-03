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
    public class OrdersController : Controller
    {
        private IRepository repo;

        public OrdersController(IRepository repo) {
            this.repo = repo;
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = repo.GetById<Order>(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return new Rotativa.ViewAsPdf(order) { FileName = order.OrderNumber.ToString() };
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumberOfTickets,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                repo.Create<Order>(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = repo.GetById<Order>(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumberOfTickets,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                repo.Update<Order>(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete<Order>(id);
            return RedirectToAction("Index");
        }
    }
}
