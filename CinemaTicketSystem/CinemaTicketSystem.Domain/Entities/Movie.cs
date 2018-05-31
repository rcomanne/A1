using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Movie : Entity<int>
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }
    
        public string ImageUrl { get; set; }

        public int YearOfRelease { get; set; }

        public int LengthInMinutes { get; set; }

        public string SpokenLanguage { get; set; }

        public string SubtitleLanguage { get; set; }

        public bool Is3D { get; set; }

        public string Director { get; set; }

        public string Trailer { get; set; }

        public string Imdb { get; set; }

        public string WebLink { get; set; }

        public int MinimumAge { get; set; }

        public string Genre { get; set; }

        public DateTime LastShowDate { get; set; }

        public virtual ICollection<Showing> Showings { get; set; }
    }
}
