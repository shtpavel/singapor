using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model;

namespace Singapor.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> predicate);
    }
}
