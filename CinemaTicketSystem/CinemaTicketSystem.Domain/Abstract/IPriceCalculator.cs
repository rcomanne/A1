using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Abstract
{
    public interface IPriceCalculator
    {
        double CalculatePrice(Showing showing);

        double CalculatePrice(Showing showing, bool isChild);
    }
}
