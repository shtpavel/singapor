using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Singapor.DAL.Filters.Abstract;
using Singapor.Model;
using Singapor.Model.Entities.Abstract;

namespace Singapor.DAL.Repositories
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
		#region Fields

		private readonly IDataContext _context;
		private readonly IEnumerable<IQueryFilterProvider<CompanyDependentEntityBase>> _companyDependentFilters; 
		#endregion

		#region Constructors

		public BaseRepository(
			IDataContext context,
			IEnumerable<ICompanyDependentQueryFilterProvider<CompanyDependentEntityBase>> companyDependentFilters)
		{
			_context = context;
			_companyDependentFilters = companyDependentFilters;
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

		public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
		{
			return GetFilteredEntities().Where(predicate);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return GetFilteredEntities();
		}

		public TEntity GetById(Guid id)
		{
			return GetFilteredEntities().FirstOrDefault(x => x.Id == id);
		}

		#endregion

		#region Private methods

		private IQueryable<TEntity> GetFilteredEntities()
		{
		    var list = _context.Set<TEntity>();
			var isCompanyDependenEntity = typeof(CompanyDependentEntityBase).IsAssignableFrom(typeof (TEntity));
			if (isCompanyDependenEntity)
			{
				var companyDependentFilteredQuery = list
                    .AsEnumerable()
                    .Cast<CompanyDependentEntityBase>()
                    .AsQueryable();

				foreach (var companyDependentFilter in _companyDependentFilters)
					companyDependentFilteredQuery = companyDependentFilteredQuery.Where(companyDependentFilter.GetFilter());

			    return companyDependentFilteredQuery.
                    AsEnumerable()
                    .Cast<TEntity>()
                    .AsQueryable();
			}
			return list.AsQueryable();
		}

		#endregion
	}
}