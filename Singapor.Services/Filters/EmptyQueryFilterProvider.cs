using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model;

namespace Singapor.Services.Filters
{
    public class EmptyQueryFilterProvider<T> : IEmptyQueryFilterProvider<T> where T: EntityBase
    {
        public Expression<Func<T, bool>> GetFilter()
        {
            var argParam = Expression.Parameter(typeof(T), "entity");
            var trueExpression = Expression.Equal(Expression.Constant(true), Expression.Constant(true));
            return Expression.Lambda<Func<T, bool>>(trueExpression, argParam);
        }
    }
}
