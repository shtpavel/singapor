using Autofac;
using Singapor.Services.Models.Maps;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class MappersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyMapper>().As<IMapConfiguration>();
			builder.RegisterType<UnitMapper>().As<IMapConfiguration>();
			builder.RegisterType<UserMapper>().As<IMapConfiguration>();
			builder.RegisterType<UtilityMapper>().As<IMapConfiguration>();
		}
	}
}