using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTicketSystem.Domain.Concrete;

namespace CinemaTicketSystem.Domain.Entities {
    public class Order : Entity<int> {
        public int ShowingId { get; set; }

        public Showing Showing { get; set; }
        
        public int NumberOfTickets { get; set; }

        public double TotalPrice { get; set; }

        public int OrderNumber { get; set; }

        public virtual ICollection<OrderSeat> OrderSeats { get; set; }

        public Order()
        {
            OrderSeats = new HashSet<OrderSeat>();
        }
    }
}
