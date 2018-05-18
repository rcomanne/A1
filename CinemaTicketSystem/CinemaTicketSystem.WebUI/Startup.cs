using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaTicketSystem.Startup))]
namespace CinemaTicketSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
