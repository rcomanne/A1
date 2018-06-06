using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Concrete
{
    public class PriceCalculator : IPriceCalculator
    {
        public double CalculatePrice(Showing showing)
        {
            return showing.Movie.LengthInMinutes > 120 ? 9.0 : 8.5;
        }

        public double CalculatePrice(Showing showing, bool isChild)
        {
            double price = CalculatePrice(showing);

            if (!isChild)
            {
                return price;
            }

            if (showing.Movie.SpokenLanguage != "Dutch")
            {
                return price;
            }

            if (showing.Start.Hour > 18)
            {
                return price;
            }

            return price - 1.5;
        }
    }
}
