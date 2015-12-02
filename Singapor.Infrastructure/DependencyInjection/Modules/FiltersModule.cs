using Autofac;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model.Entities;
using Singapor.Model.Entities.Abstract;
using Singapor.Services.Filters;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class FiltersModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<BaseCompanyDependentQueryFilterProvider>().As<ICompanyDependentQueryFilterProvider<CompanyDependentEntityBase>>();
			builder.RegisterType<EmptyQueryFilterProvider<Role>>().As<IQueryFilterProvider<Role>>();
			builder.RegisterType<EmptyQueryFilterProvider<Company>>().As<IQueryFilterProvider<Company>>();
			builder.RegisterType<SoftDeleteFilterProvider>().As<ICompanyDependentQueryFilterProvider<CompanyDependentEntityBase>>();
		}
	}
}