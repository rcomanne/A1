using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Entities {
    public class Survey : Entity<int> {
        public int OverallExperience { get; set; }
        public int MovieExperience { get; set; }
        public int TravelExperience { get; set; }
        public int BathroomExperience { get; set; }
        public int ShopExperience { get; set; }
        public int FoodExperience { get; set; }
        public int StaffExperience { get; set; }
        public string Comment { get; set; }
    }
}
