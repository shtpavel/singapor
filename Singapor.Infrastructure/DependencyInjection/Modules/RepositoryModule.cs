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
			builder.RegisterType<BaseRepository<Company>>().As<IRepository<Company>> ();
			builder.RegisterType<BaseRepository<Unit>>().As<IRepository<Unit>>();
			builder.RegisterType<BaseRepository<UnitType>>().As<IRepository<UnitType>>();
			builder.RegisterType<BaseRepository<User>>().As<IRepository<User>>();
			builder.RegisterType<BaseRepository<Service>>().As<IRepository<Service>>();
			builder.RegisterType<BaseRepository<Role>>().As<IRepository<Role>>();
		}
	}
}
