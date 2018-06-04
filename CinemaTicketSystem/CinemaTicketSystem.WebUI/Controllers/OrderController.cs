using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IRepository repo;

        public OrderController(IRepository repo)
        {
            this.repo = repo;
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

            IEnumerable<Seat> seats = repo.Get<Seat>(s => s.RoomId == showing.RoomId, q => q.OrderBy(s => s.Row).OrderBy(s => s.Number));
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

            //Get best seats as default.

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

            Order order = new Order() { NumberOfTickets = seats.Count(), ShowingId = showing.Id };
            repo.Create<Order>(order);
            repo.Save();

            foreach (int seatId in seats)
            {
                repo.Create<OrderSeat>(new OrderSeat() { OrderId = order.Id, SeatId = seatId });
            }
            repo.Save();

            return View(showing);
        }

    }
}