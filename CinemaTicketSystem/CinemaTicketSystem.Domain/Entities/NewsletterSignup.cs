using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Entities
{
    public class NewsletterSignup : Entity<int>
    {
        public string Email { get; set; }

        public string VerificationToken { get; set; }

        public bool Verified { get; set; }
    }
}
