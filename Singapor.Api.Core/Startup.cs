using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Singapor.Infrastructure;
using Singapor.Services.Models.Maps;

namespace Singapor.Api.Core
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }


		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			var builder = ConfigureContainer();
			builder.Populate(services);

			var container = builder.Build();
			return container.Resolve<IServiceProvider>();
		}

		private ContainerBuilder ConfigureContainer()
		{
			var container = new ApplicationContainer().GetContainerBuilder();
			var builder = new ContainerBuilder();
			builder.Update(container);

			container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());

			return builder;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
