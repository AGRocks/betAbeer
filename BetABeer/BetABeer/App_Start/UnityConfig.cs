using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BetABeer.Model.Utilities;
using BetABeer.Model;
using System.Web.Http;

namespace BetABeer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDbDataProvider, ModelContext>(new HierarchicalLifetimeManager())
                     .RegisterType(typeof(IRepository<>), typeof(Repository<>), new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}