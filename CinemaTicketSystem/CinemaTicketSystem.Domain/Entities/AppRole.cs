using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CinemaTicketSystem.Domain.Entities {
    public class AppRole : IdentityRole {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
