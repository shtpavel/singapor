using Autofac;
using Singapor.Services.Models;
using Singapor.Tests.Generators;
using Singapor.Tests.Generators.Unit;

namespace Singapor.Tests.Infrastructure.Modules
{
	public class GeneratorsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyModelGenerator>().As<IGenerator<CompanyModel>>();
			builder.RegisterType<UnitModelGenerator>().As<IUnitModelGenerator>();
			builder.RegisterType<UnitTypeModelGenerator>().As<IUnitTypeModelGenerator>();
            builder.RegisterType<UtilityModelGenerator>().As<IUtilityModelGenerator>();
		}
	}
}