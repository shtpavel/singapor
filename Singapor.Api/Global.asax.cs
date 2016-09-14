using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Singapor.Infrastructure;
using Singapor.Services.Events;
using Singapor.Services.Models.Maps;

namespace Singapor.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            var applicationContainer = new ApplicationContainer();
            var builder = applicationContainer.GetContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            var newContainerBuilder = new ContainerBuilder();
            newContainerBuilder.RegisterInstance(container).SingleInstance();
            newContainerBuilder.Update(container);

            container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());
            container.Resolve<IEventRegisterListeners>().RegisterListeners();
        }
    }
}
