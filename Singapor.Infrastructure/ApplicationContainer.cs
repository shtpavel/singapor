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

        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            RegisterModules(builder);
            return builder.Build();
        }

        #endregion

        protected virtual void RegisterModules(ContainerBuilder builder)
        {
	        builder.RegisterModule<ContextModule>();
	        builder.RegisterModule<RepositoryModule>();
	        builder.RegisterModule<ServiceModule>();
	        builder.RegisterModule<MappersModule>();
        }
    }
}