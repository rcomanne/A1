using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.Domain.Abstract;
using System.Net;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        IRepository repo;

        public OrderController(IRepository repo) {
            this.repo = repo;
        }

        // GET Home voor het invoeren van order nummer
        [HttpGet]
        public ViewResult Index() {
            return View();
        }

        // GET Edit
        public ViewResult Edit(int? id) {
            return View(repo.GetById<Order>(id));
        }

        [HttpPost]
        public ActionResult GetOrder(int orderNumber) {
            return Details(orderNumber);
        }

        [HttpGet]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = repo.GetById<Order>(id);
            if (order == null) {
                IEnumerable<Order> orders = repo.Get<Order>(q => q.OrderNumber == id);
                if (orders == null) {
                    return HttpNotFound();
                }
                order = orders.ElementAt<Order>(0);
                if (order == null) {
                    return HttpNotFound();
                }
            }
            order.Showing = repo.GetById<Showing>(order.ShowingId);
            return new Rotativa.ViewAsPdf(order);
        }
    }
}