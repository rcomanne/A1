using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Concrete;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTicketSystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBindings()
        {
            kernel.Bind<ApplicationDbContext>()
                .ToSelf()
                .InRequestScope();
            kernel.Bind<IRepository>()
                .To<EntityFrameworkRepository<ApplicationDbContext>>()
                .InRequestScope();

            kernel.Bind<IMailer>()
                .To<SmtpMailer>()
                .InRequestScope();

            kernel.Bind<ITokenGenerator>()
                .To<RandomTokenGenerator>();
        }
    }
}