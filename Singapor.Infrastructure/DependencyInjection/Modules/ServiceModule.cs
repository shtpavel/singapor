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
			builder.RegisterType<OrderService>().As<IOrderService>();
			builder.RegisterType<CompanyService>().As<ICompanyService>();
			builder.RegisterType<UnitScheduleService>().As<IUnitScheduleService>();
			builder.RegisterType<UnitService>().As<IUnitService>();
			builder.RegisterType<UnitTypeService>().As<IUnitTypeService>();
			builder.RegisterType<FieldValueService>().As<IFieldValueService>();
			builder.RegisterType<FieldValidatorService>().As<IFieldValidatorService>();
			builder.RegisterType<FieldService>().As<IFieldService>();
			builder.RegisterType<UserService>().As<IUserService>();
		}
	}
}
