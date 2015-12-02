using Autofac;
using Singapor.Infrastructure.DependencyInjection.Modules;

namespace Singapor.Infrastructure
{
	public class ApplicationContainer
	{
		#region Public methods

		public IContainer GetContainerBuilder()
		{
			var builder = new ContainerBuilder();
			RegisterModules(builder);

			var container = builder.Build();

			//Register container itself
			var newContainerBuilder = new ContainerBuilder();
			newContainerBuilder.RegisterInstance(container).SingleInstance();
			newContainerBuilder.Update(container);

			return container;
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