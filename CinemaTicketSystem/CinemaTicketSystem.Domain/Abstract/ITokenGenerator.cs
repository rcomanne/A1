using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Abstract
{
    public interface ITokenGenerator
    {
        String Generate(int length);
    }
}
