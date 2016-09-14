using System;
using System.Linq.Expressions;
using Singapor.Model;
using Singapor.Model.Entities.Abstract;

namespace Singapor.DAL.Filters.Abstract
{
	public interface IQueryFilterProvider<T> where T : EntityBase
	{
		#region Public methods

	    Expression<Func<T, bool>> GetFilter();

	    #endregion
	}
}