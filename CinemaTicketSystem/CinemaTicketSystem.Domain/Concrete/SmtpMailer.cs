using CinemaTicketSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Domain.Concrete
{
    public class SmtpMailer : IMailer
    {
        public SmtpClient GetClient()
        {
            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525);
            client.Credentials = new NetworkCredential("955a43d3494f7e", "32033d8905bd14");
            client.EnableSsl = true;

            return client;
        }

        public void Send(MailMessage message)
        {
            message.From = new MailAddress("info@cinematicketsystem.nl", "CinemaTicketSystem");
            message.Bcc.Add(new MailAddress("info@cinematicketsystem.nl", "CinemaTicketSystem"));

            using (var client = GetClient())
            {
                client.Send(message);
            }
        }
    }
}
