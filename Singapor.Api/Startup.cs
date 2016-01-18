using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Singapor.Api.Auth;
using Singapor.Infrastructure;
using Singapor.Services.Abstract;
using Singapor.Services.Auth;
using Singapor.Services.Models.Maps;

[assembly: OwinStartup(typeof(Singapor.Api.Startup))]

namespace Singapor.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            CongfigureRoutes(config);
            ConfigureFormatters(config);

            var container = ConfigureContainer();
            var dependencyResolver = new AutofacWebApiDependencyResolver(container);
            ConfigureOAuth(appBuilder, container);
            config.DependencyResolver = dependencyResolver;
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));
            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseWebApi(config); 
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ApplicationContainer().GetContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            var container = builder.Build();
            container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());

            return container;
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
        }

        private void CongfigureRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(container)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
