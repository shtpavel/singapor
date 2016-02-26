using System;
using System.Linq.Expressions;
using Singapor.Model.Entities.Abstract;

namespace Singapor.DAL.Filters.Abstract
{
    public interface ICompanyDependentQueryFilterProvider<T> 
        : IQueryFilterProvider<T> where T: CompanyDependentEntityBase
    {
        Expression<Func<T, bool>> GetFilter();
    }
}