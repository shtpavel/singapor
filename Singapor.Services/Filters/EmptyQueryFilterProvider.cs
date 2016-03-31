using System;
using System.Linq.Expressions;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Services.Filters
{
	public class EmptyQueryFilterProvider<T> : IEmptyQueryFilterProvider<T> where T : EntityBase
	{
		#region Public methods

		public Expression<Func<T, bool>> GetFilter()
		{
			var argParam = Expression.Parameter(typeof (T), "entity");
			var trueExpression = Expression.Equal(Expression.Constant(true), Expression.Constant(true));
			return Expression.Lambda<Func<T, bool>>(trueExpression, argParam);
		}

		#endregion
	}
}