using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Room : Entity<int>
    {
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public virtual IEnumerable<Showing> Showings { get; set; }
    }
}
