using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Seat : Entity<int>
    {

        [Index("IX_NumberRowRoom", 1)]
        public int RoomId { get; set; }

        [Index("IX_NumberRowRoom", 2)]
        public int Row { get; set; }

        [Index("IX_NumberRowRoom", 3)]
        public int Number { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<OrderSeat> OrderSeats { get; set; }

        public Seat()
        {
            OrderSeats = new HashSet<OrderSeat>();
        }
    }
}
