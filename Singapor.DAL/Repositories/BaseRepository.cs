using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Singapor.Model;

namespace Singapor.DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        #region Fields

        private readonly IDataContext _context;

        #endregion

        #region Constructors

        public BaseRepository(IDataContext context)
        {
            _context = context;
        }

        #endregion

        #region Public methods

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

        public virtual IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        #endregion
    }
}