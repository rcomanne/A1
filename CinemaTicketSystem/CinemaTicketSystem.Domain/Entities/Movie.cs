using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Movie : Entity<int>
    {
        public string Name { get; set; }
    
        public string ImageUrl { get; set; }

        public int YearOfRelease { get; set; }

        public int LengthInMinutes { get; set; }

        public string SpokenLanguage { get; set; }

        public int MinimumAge { get; set; }

        public string Genre { get; set; }

        public virtual ICollection<Showing> Showings { get; set; }
    }
}
