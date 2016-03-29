using Singapor.Model;

namespace Singapor.DAL.Filters.Abstract
{
	public interface IEmptyQueryFilterProvider<T> : IQueryFilterProvider<T> where T : EntityBase
	{
	}
}