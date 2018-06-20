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
using System.Security.Cryptography;
using System.Text;

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
                string hashed = Hash(model.Password);
                AppUser user = userManager.FindByName(model.UserName);
                if (user != null && userManager.ValidatePassword(user, hashed)) {
                    user.SecurityStamp = CreateStamp();
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                    if (userManager.IsInRole(user.Id, "Admin")) {
                        return View("../Auth/Admin");
                    }
                    return Redirect(Url.Action("Index", "Movie"));
                }
            }
            return Redirect(Url.Action("Index", "Auth"));
        }

        public ActionResult Admin() {
            return View();
        }

        public ActionResult CreateRole(string roleName) {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
            if (!roleManager.RoleExists(roleName)) {
                roleManager.Create(new AppRole(roleName));
            }
            return Redirect(Url.Action("Index", "Auth"));
        }

        private string Hash(string text) {
            var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private string CreateStamp() {
            return DateTime.Now.Millisecond.ToString();
        }
    }
}