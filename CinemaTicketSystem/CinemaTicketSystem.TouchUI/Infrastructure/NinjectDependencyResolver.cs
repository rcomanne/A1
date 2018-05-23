using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaTicketSystem.Domain.Abstract;
using CinemaTicketSystem.Domain.Concrete;
using Ninject.Web.Common;
using System.Data.Entity;

namespace CinemaTicketSystem.TouchUI.Infrastructure
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
        }
    }
}