using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IRepository repo;
        private IPriceCalculator priceCalculator;

        private IMailer mailer;

        public OrderController(IRepository repo, IMailer mailer, IPriceCalculator priceCalculator)
        {
            this.repo = repo;
            this.mailer = mailer;
            this.priceCalculator = priceCalculator;
        }

        public ActionResult CreateStepOne(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showing showing = repo.GetById<Showing>(id);
            if (showing == null)
            {
                return HttpNotFound();
            }

            return View(showing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepTwo(int? id, int ticketsAdults, int ticketsChildren)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showing showing = repo.GetById<Showing>(id);
            if (showing == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Seat> seats = repo.Get<Seat>(s => s.RoomId == showing.RoomId,
                q => q.OrderBy(s => s.Row).OrderBy(s => s.Number));
            Seat[,] room = new Seat[seats.Max(s => s.Row), seats.Max(s => s.Number)];
            foreach (var seat in seats)
            {
                room[seat.Row - 1, seat.Number - 1] = seat;
            }

            IEnumerable<OrderSeat> takenSeats = repo.Get<OrderSeat>(os => os.Order.ShowingId == showing.Id);
            ViewBag.TakenSeats = takenSeats.Select(os => os.SeatId).ToArray();
            ViewBag.Room = room;
            ViewBag.TicketsAdults = ticketsAdults;
            ViewBag.TicketsChildren = ticketsChildren;

            return View(showing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepThree(int? id, int ticketsChildren, int[] seats)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showing showing = repo.GetById<Showing>(id);
            if (showing == null)
            {
                return HttpNotFound();
            }


            double price = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                price += priceCalculator.CalculatePrice(showing, i < ticketsChildren);
            }

            Order order = new Order() {
                NumberOfTickets = seats.Length,
                ShowingId = showing.Id,
                TotalPrice = price,
            };

            repo.Create<Order>(order);
            repo.Save();

            foreach (int seatId in seats)
            {
                repo.Create<OrderSeat>(new OrderSeat() {OrderId = order.Id, SeatId = seatId});
            }

            repo.Save();

            ViewBag.ShowingID = id;
            ViewBag.OrderID = order.Id;

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStepFour(int? id, int orderId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showing showing = repo.GetById<Showing>(id);
            if (showing == null)
            {
                return HttpNotFound();
            }

            ViewBag.ShowingID = id;
            ViewBag.OrderID = orderId;

            return View(showing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThankYou(int? id, string email, int orderId)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showing showing = repo.GetById<Showing>(id);
            if (showing == null)
            {
                return HttpNotFound();
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(email));
                mail.Body = String.Format($"Bedankt voor uw bestelling bij Avans Bioscopen! Uw ordernummer is: {orderId}. Veel kijkplezier!");
                mail.IsBodyHtml = true;
                mailer.Send(mail);
            }
            catch (Exception e)
            {
                Response.Write("Error " + e.ToString());
            }

            ViewBag.ShowingID = id;

            return View(showing);
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
            Order order = repo.GetFirst<Order>(q => q.OrderNumber == orderNumber);
            if (order == null) {
                order = repo.GetFirst<Order>(q => q.Id == orderNumber);
                if (order == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            if (order.Showing == null) {
                order.Showing = repo.GetById<Showing>(order.ShowingId);
            }
            return new Rotativa.ViewAsPdf(order);
        }

        [HttpGet]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = repo.GetById<Order>(id);
            if (order == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (order.Showing == null) {
                order.Showing = repo.GetById<Showing>(order.ShowingId);
            }
            
            return new Rotativa.ViewAsPdf(order);
        }
    }
}