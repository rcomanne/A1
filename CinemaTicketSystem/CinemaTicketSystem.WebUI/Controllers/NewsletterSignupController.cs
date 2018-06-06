using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NewsletterSignupController : Controller
    {
        IRepository repo;

        IMailer mailer;

        ITokenGenerator tokenGenerator;

        public NewsletterSignupController(IRepository repo, IMailer mailer, ITokenGenerator tokenGenerator)
        {
            this.repo = repo;
            this.mailer = mailer;
            this.tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(string Email)
        {
            NewsletterSignup signup = repo.GetFirst<NewsletterSignup>(ns => ns.Email == Email);

            if (signup == null)
            {
                signup = new NewsletterSignup() { Email = Email, VerificationToken = tokenGenerator.Generate(16), Verified = false };
                repo.Create<NewsletterSignup>(signup);
            }
            else
            {
                signup.VerificationToken = tokenGenerator.Generate(16);
                repo.Update<NewsletterSignup>(signup);
            }
            repo.Save();

            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(Email));
            var link = new Uri(HttpContext.Request.Url, Url.Action("Verify", new { token = signup.VerificationToken }));
            mail.Body = String.Format("Welkom bij de CinemaTicketSystem nieuwsbrief,<br><a href=\"{0}\">Valideer je e-mailadres.</a>", link);
            mail.IsBodyHtml = true;
            mailer.Send(mail);
            
            return View(signup);
        }

        public ActionResult Verify(string token)
        {
            NewsletterSignup signup = repo.GetFirst<NewsletterSignup>(ns => ns.VerificationToken == token);
            
            if (signup != null)
            {
                signup.Verified = true;
                signup.VerificationToken = null;
                repo.Update<NewsletterSignup>(signup);
                repo.Save();
            }

            return View(signup);
        }
    }
}