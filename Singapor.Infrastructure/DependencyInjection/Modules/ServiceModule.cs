using Autofac;
using Singapor.Resources.Providers;
using Singapor.Services.Abstract;
using Singapor.Services.Services;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyService>().As<ICompanyService>();
			builder.RegisterType<UnitService>().As<IUnitService>();
			builder.RegisterType<UnitTypeService>().As<IUnitTypeService>();
			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<UtilityService>().As<IUtilityService>();

			builder.RegisterType<TranslationsService>().As<ITranslationsService>().InstancePerLifetimeScope();
			builder.RegisterType<TranslationsProvider>().As<ITranslationsProvider>().InstancePerLifetimeScope();
		}
	}
}