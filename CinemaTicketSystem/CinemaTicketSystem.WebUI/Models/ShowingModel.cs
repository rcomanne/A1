using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaTicketSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models {
    public class ShowingModel {
        [Required]
        public DateTime Start { get; set; }
        public string Movie { get; set; }
        public int Room { get; set; }
        public bool Is3D { get; set; }
    }
}