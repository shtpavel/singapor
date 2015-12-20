using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model;

namespace Singapor.DAL.Repositories
{
    public class BaseRepository <TEntity>: IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IDataContext _context;

        public BaseRepository(IDataContext context)
        {
            _context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var set = _context.Set<TEntity>();
            set.Add(entity);

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}
