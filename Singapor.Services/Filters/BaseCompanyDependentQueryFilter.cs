using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Singapor.Common.Contexts;
using Singapor.Common.Exceptions;
using Singapor.DAL.Filters.Abstract;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Model.Entities.Abstract;
using Singapor.Services.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Filters
{
    public class BaseCompanyDependentQueryFilterProvider<T> : ICompanyDependentQueryFilterProvider<T> where T: CompanyDependentEntityBase
    {
        private readonly IUserContext _userContext;

        public BaseCompanyDependentQueryFilterProvider(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public Expression<Func<T, bool>> GetFilter()
        {
            if (!_userContext.UserId.HasValue)
                throw new SingaporException("BaseCompanyDependentQueryFilter.Filter. Can't find userd in user context.");

            var argParam = Expression.Parameter(typeof(CompanyDependentEntityBase), "entity");
            if (_userContext.IsInRole(RoleIds.SuperAdmin))
            {
                var trueExpression = Expression.Equal(argParam, Expression.Constant(true));
                return Expression.Lambda<Func<T, bool>>(trueExpression, argParam);
            }

            var companyIdProperty = Expression.Property(argParam, "CompanyId");
            var equalsExpression = Expression.Equal(companyIdProperty, Expression.Constant(_userContext.UserCompanyId));
            return Expression.Lambda<Func<T, bool>>(equalsExpression, argParam);
        }
    }
}
