using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Abstract
{
    public interface IMailer
    {
        void Send(MailMessage message);
    }
}
