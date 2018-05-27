using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Showing : Entity<int>
    {
        public DateTime Start { get; set; }

        public int MovieId { get; set; }

        public int RoomId { get; set; }

        public virtual Movie Movie {get; set;}

        public virtual Room Room { get; set; }
    }
}
