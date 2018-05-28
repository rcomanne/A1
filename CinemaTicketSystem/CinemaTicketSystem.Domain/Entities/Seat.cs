using CinemaTicketSystem.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTicketSystem.Domain.Entities
{
    public class Seat : Entity<int>
    {
        public Boolean Available { get; set; }

        [Index("IX_NumberRowRoom", 1, IsUnique = true)]
        public int Number { get; set; }

        [Index("IX_NumberRowRoom", 2, IsUnique = true)]
        public int Row { get; set; }

        [Index("IX_NumberRowRoom", 3, IsUnique = true)]
        public virtual Room Room { get; set; }

    }
}
