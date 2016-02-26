using System;
using System.Linq.Expressions;
using Singapor.Common.Contexts;
using Singapor.Common.Exceptions;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model.Entities.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Filters
{
    public class BaseCompanyDependentQueryFilterProvider<T> : ICompanyDependentQueryFilterProvider<T>
        where T : CompanyDependentEntityBase
    {
        #region Fields

        private readonly IUserContext _userContext;

        #endregion

        #region Constructors

        public BaseCompanyDependentQueryFilterProvider(IUserContext userContext)
        {
            _userContext = userContext;
        }

        #endregion

        #region Public methods

        public Expression<Func<T, bool>> GetFilter()
        {
            if (!_userContext.UserId.HasValue)
                throw new SingaporException("BaseCompanyDependentQueryFilter.Filter. Can't find userd in user context.");

            var argParam = Expression.Parameter(typeof (CompanyDependentEntityBase), "entity");
            if (_userContext.IsInRole(RoleIds.SuperAdmin))
            {
                var trueExpression = Expression.Equal(Expression.Constant(true), Expression.Constant(true));
                return Expression.Lambda<Func<T, bool>>(trueExpression, argParam);
            }

            var companyIdProperty = Expression.Property(argParam, "CompanyId");
            var equalsExpression = Expression.Equal(companyIdProperty, Expression.Constant(_userContext.UserCompanyId));
            return Expression.Lambda<Func<T, bool>>(equalsExpression, argParam);
        }

        #endregion
    }
}