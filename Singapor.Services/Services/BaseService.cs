using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Repositories;
using Singapor.Model;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Utils;

namespace Singapor.Services.Services
{
    public class BaseService<TModel, TEntity> : IService<TModel> where TModel : ModelBase where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Guid Create(TModel model)
        {
            var company = Mapper.Map(model, Activator.CreateInstance<TEntity>());
            var entity = _repository.Add(company);
            _repository.SaveChanges();
            return entity.Id;
        }

        public virtual void Delete(Guid id)
        {
            var company = _repository.GetById(id);
            if (company == null)
                return;
            _repository.Delete(company);
            _repository.SaveChanges();
        }

        public virtual Guid Update(TModel model)
        {
            var existingItem = _repository.GetById(model.Id);

            Mapper.Map(model, existingItem);
            _repository.SaveChanges();

            return existingItem.Id;
        }

        public virtual TModel Get(Guid id)
        {
            var entity = _repository.GetById(id);

            var company = Mapper.Map(entity, Activator.CreateInstance<TModel>());

            return company;
        }

        public IEnumerable<TModel> Get()
        {
            return _repository.GetAll().Select(x => Mapper.Map(x, Activator.CreateInstance<TModel>()));
        }
    }
}
