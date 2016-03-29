﻿using Autofac;
using Singapor.Services.Abstract;
using Singapor.Services.Services;

namespace Singapor.Infrastructure.DependencyInjection.Module
{
	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyService>().As<ICompanyService>();
			builder.RegisterType<UnitService>().As<IUnitService>();
			builder.RegisterType<UnitTypeService>().As<IUnitTypeService>();
			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<ServiceService>().As<IServiceService>();
		}
	}
}