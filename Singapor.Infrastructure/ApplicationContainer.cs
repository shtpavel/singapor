using Autofac;
using Singapor.Infrastructure.DependencyInjection.Modules;

namespace Singapor.Infrastructure
{
	public class ApplicationContainer
	{
		#region Public methods

		public ContainerBuilder GetContainerBuilder()
		{
			var builder = new ContainerBuilder();
			RegisterModules(builder);

            return builder;
		}

		#endregion

		protected virtual void RegisterModules(ContainerBuilder builder)
		{
			builder.RegisterModule<ContextModule>();
			builder.RegisterModule<RepositoryModule>();
			builder.RegisterModule<ServiceModule>();
			builder.RegisterModule<MappersModule>();
			builder.RegisterModule<ApplicationServiceModule>();
			builder.RegisterModule<EventSystemModule>();
			builder.RegisterModule<FiltersModule>();
		}
	}
}