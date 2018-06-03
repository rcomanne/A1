using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaTicketSystem.WebUI.Models
{
    public class MovieDetails
    {
        [Required]
        public Movie Movie { get; set; }

        [Required]
        public IEnumerable<Showing> Showings { get; set; }
    }
}