using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using CinemaTicketSystem.Domain.Entities;
using CinemaTicketSystem.Domain.Concrete;

namespace WebUI.UserManagement {
    public class AppUserManager : UserManager<AppUser> {
        public AppUserManager(IUserStore<AppUser> store) : base(store) { }

        public static AppUserManager Create (IdentityFactoryOptions<AppUserManager> options, IOwinContext context) {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<ApplicationDbContext>()));

            manager.AddToRole(manager.FindByName("admin").Id, "Admin");
            manager.AddToRole(manager.FindByName("employee").Id, "Employee");
            return manager;
        }

        public Boolean ValidatePassword(AppUser user, String hash) {
            return user.PasswordHash.Equals(hash);
        }
    }
}