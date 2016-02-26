using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Singapor.Common.Contexts;
using Singapor.DAL;

namespace Singapor.Infrastructure.DependencyInjection.Module
{
	public class ContextModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DataContext>().As<IDataContext>().As<IUnitOfWork>().InstancePerRequest();
			builder.RegisterType<UserContext>().As<IUserContext>().InstancePerRequest();
		}
	}
}
