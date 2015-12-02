using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Services.Filters
{
	public class SoftDeleteFilterProvider : ICompanyDependentQueryFilterProvider<CompanyDependentEntityBase>
	{
		public Expression<Func<CompanyDependentEntityBase, bool>> GetFilter()
		{
			var argParam = Expression.Parameter(typeof(CompanyDependentEntityBase), "entity");
			var companyIdProperty = Expression.Property(argParam, "IsDeleted");
			var equalsExpression = Expression.NotEqual(companyIdProperty, Expression.Constant(true));
			return Expression.Lambda<Func<CompanyDependentEntityBase, bool>>(equalsExpression, argParam);
		}
	}
}
