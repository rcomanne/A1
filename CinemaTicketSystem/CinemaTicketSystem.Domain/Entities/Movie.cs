﻿using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Movie : Entity<int>
    {
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Showing> Showings { get; set; }
    }
}
