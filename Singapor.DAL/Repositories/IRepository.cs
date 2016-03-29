using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Singapor.Model;

namespace Singapor.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        #region Public methods

        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        

        #endregion
    }
}