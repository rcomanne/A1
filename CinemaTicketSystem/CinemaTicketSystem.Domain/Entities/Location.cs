using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Location : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public Location()
        {
            Rooms = new HashSet<Room>();
        }
    }
}
