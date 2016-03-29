using Autofac;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model.Entities;
using Singapor.Services.Filters;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class FiltersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<BaseCompanyDependentQueryFilterProvider<User>>().As<IQueryFilterProvider<User>>();
			builder.RegisterType<BaseCompanyDependentQueryFilterProvider<Unit>>().As<IQueryFilterProvider<Unit>>();
			builder.RegisterType<BaseCompanyDependentQueryFilterProvider<Service>>().As<IQueryFilterProvider<Service>>();
			builder.RegisterType<BaseCompanyDependentQueryFilterProvider<UnitType>>().As<IQueryFilterProvider<UnitType>>();
			builder.RegisterType<EmptyQueryFilterProvider<Role>>().As<IQueryFilterProvider<Role>>();
			builder.RegisterType<EmptyQueryFilterProvider<Company>>().As<IQueryFilterProvider<Company>>();
		}
	}
}