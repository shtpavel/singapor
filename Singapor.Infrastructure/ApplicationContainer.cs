using Autofac;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Infrastructure.DependencyInjection.Module;
using Singapor.Infrastructure.DependencyInjection.Modules;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Maps;
using Singapor.Services.Services;

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
        }
    }
}