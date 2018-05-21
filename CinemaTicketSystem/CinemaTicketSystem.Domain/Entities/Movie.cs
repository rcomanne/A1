using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Movie : Entity<int>
    {
        public virtual IEnumerable<Showing> Showings { get; set; }
    }
}
