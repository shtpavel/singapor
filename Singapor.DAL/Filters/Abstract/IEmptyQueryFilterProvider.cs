using Singapor.Model;
using Singapor.Model.Entities.Abstract;

namespace Singapor.DAL.Filters.Abstract
{
	public interface IEmptyQueryFilterProvider<T> : IQueryFilterProvider<T> where T : EntityBase
	{
	}
}