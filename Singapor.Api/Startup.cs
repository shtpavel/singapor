using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Singapor.Api.Auth;
using Singapor.Infrastructure;
using Singapor.Services.Models.Maps;
using Singapor.Services.Events;

[assembly: OwinStartup(typeof (Singapor.Api.Startup))]

namespace Singapor.Api
{
	public class Startup
	{
		#region Public methods

		public void Configuration(IAppBuilder appBuilder)
		{
			HttpConfiguration config = new HttpConfiguration();
			CongfigureRoutes(config);
			ConfigureFormatters(config);
			var container = ConfigureContainer();
			var dependencyResolver = new AutofacWebApiDependencyResolver(container);

			ConfigureOAuth(appBuilder, container);
			config.IncludeErrorDetailPolicy
				= IncludeErrorDetailPolicy.Always;
			config.DependencyResolver = dependencyResolver;
			config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));

			appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			appBuilder.UseAutofacMiddleware(container);
			appBuilder.UseWebApi(config);
		}

		public void ConfigureOAuth(IAppBuilder app, IContainer container)
		{
			var issuer = WebConfigurationManager.AppSettings["issuer"];
			var audience = WebConfigurationManager.AppSettings["audience"];
			var secret = WebConfigurationManager.AppSettings["base64secret"];

			var oAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/api/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				AccessTokenFormat = new CustomJwtFormat(WebConfigurationManager.AppSettings["issuer"]),
				Provider = new SimpleAuthorizationServerProvider(container)
			};

			app.UseJwtBearerAuthentication(
				new JwtBearerAuthenticationOptions
				{
					AllowedAudiences = new[] {audience},
					IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
					{
						new SymmetricKeyIssuerSecurityTokenProvider(issuer, TextEncodings.Base64Url.Decode(secret))
					}
				});
			app.UseOAuthAuthorizationServer(oAuthServerOptions);
		}

		#endregion

		#region Private methods

		private static IContainer ConfigureContainer()
		{
			var container = new ApplicationContainer().GetContainerBuilder();

			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
			builder.Update(container);

			container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());
            container.Resolve<IEventRegisterListeners>().RegisterListeners();


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

		#endregion
	}
}