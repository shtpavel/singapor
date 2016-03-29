using Singapor.Model.Entities.Abstract;

namespace Singapor.DAL.Filters.Abstract
{
	public interface ICompanyDependentQueryFilterProvider<T>
		: IQueryFilterProvider<T> where T : CompanyDependentEntityBase
	{
	}
}