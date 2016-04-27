using Autofac;
using Singapor.Common.Contexts;
using Singapor.DAL;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class ContextModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DataContext>().As<IDataContext>().As<IUnitOfWork>().InstancePerLifetimeScope();
			builder.RegisterType<UserContext>().As<IUserContext>().InstancePerLifetimeScope();
			builder.RegisterType<UserSettingsContext>().As<IUserSettingsContext>().As<IUserSettingsContextSettable>().InstancePerLifetimeScope();
		}
	}
}