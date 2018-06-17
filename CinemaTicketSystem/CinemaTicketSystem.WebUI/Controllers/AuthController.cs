using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebUI.UserManagement;
using CinemaTicketSystem.Domain.Entities;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model) {
            if (ModelState.IsValid) {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                string base64 = Base64Encode(model.Password);
                AppUser user = userManager.FindByName(model.UserName);
                Boolean valid = userManager.CheckPassword(user, base64);
                Boolean unhashedValid = userManager.CheckPassword(user, model.Password);
                if (user != null && userManager.ValidatePassword(user, base64)) {
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(Url.Action("Index", "Home"));
                }
            }
            return Redirect(Url.Action("Index", "Auth"));
        }

        public ActionResult CreateRole(string roleName) {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
            if (!roleManager.RoleExists(roleName)) {
                roleManager.Create(new AppRole(roleName));
            }
            return Redirect(Url.Action("Index", "Auth"));
        }

        private string Base64Encode(string text) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}