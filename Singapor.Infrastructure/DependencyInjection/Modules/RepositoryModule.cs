using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;

namespace Singapor.Infrastructure.DependencyInjection.Module
{
	public class RepositoryModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CompanyRepository>().As<IRepository<Company>> ();
			builder.RegisterType<OrderRepository>().As<IRepository<Order>>();
			builder.RegisterType<UnitScheduleRepository>().As<IRepository<UnitSchedule>>();
			builder.RegisterType<UnitRepository>().As<IRepository<Unit>>();
			builder.RegisterType<BaseRepository<UnitType>>().As<IRepository<UnitType>>();
			builder.RegisterType<BaseRepository<FieldValidator>>().As<IRepository<FieldValidator>>();
			builder.RegisterType<BaseRepository<Field>>().As<IRepository<Field>>();
			builder.RegisterType<BaseRepository<FieldValue>>().As<IRepository<FieldValue>>();
			builder.RegisterType<BaseRepository<User>>().As<IRepository<User>>();
			builder.RegisterType<BaseRepository<Service>>().As<IRepository<Service>>();
		}
	}
}
