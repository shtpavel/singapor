using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Singapor.Services.Abstract;
using Singapor.Services.Services;

namespace Singapor.Infrastructure.DependencyInjection.Module
{
	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitService>().As<IUnitService>().InstancePerLifetimeScope();
            builder.RegisterType<UnitTypeService>().As<IUnitTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceService>().As<IServiceService>().InstancePerLifetimeScope();
		}
	}
}
