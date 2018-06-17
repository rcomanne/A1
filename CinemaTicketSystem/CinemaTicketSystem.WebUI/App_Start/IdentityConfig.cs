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
using CinemaTicketSystem.Domain.Concrete;
using CinemaTicketSystem.Domain.Entities;
using WebUI.UserManagement;

namespace WebUI.App_Start {
    public class IdentityConfig {
        public void Configuration(IAppBuilder app) {
            app.CreatePerOwinContext(() => new ApplicationDbContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<ApplicationDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login"),
            });
        }
    }
}