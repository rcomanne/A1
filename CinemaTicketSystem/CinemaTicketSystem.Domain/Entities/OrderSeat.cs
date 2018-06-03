using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketSystem.Domain.Entities
{
    public class OrderSeat : Entity<int>
    {
        [Index("IX_OrderSeat", IsUnique = true, Order = 0)]
        public int OrderId { get; set; }

        [Index("IX_OrderSeat", IsUnique = true, Order = 1)]
        public int SeatId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Seat Seat { get; set; }
    }
}
