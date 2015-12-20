using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Responses;
using Singapor.Utils;

namespace Singapor.Services.Services
{
    public class BaseService<TModel, TEntity> : IService<TModel> where TModel : ModelBase where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _untOfWork;
        protected readonly IRepository<TEntity> _repository;

        public BaseService(IUnitOfWork untOfWork, IRepository<TEntity> repository)
        {
            _untOfWork = untOfWork;
            _repository = repository;
        }

        public virtual SingleEntityResponse<TModel> Create(TModel model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();
            var data = Mapper.Map(model, Activator.CreateInstance<TEntity>());

            var validationResult = new CommonValidator<TModel>(this).Validate(model);
            if (!validationResult.IsValid)
                return new SingleEntityResponse<TModel>(model, validationResult.GetErrorsObjects().ToList());

            var entity = _repository.Add(data);
            
            return new SingleEntityResponse<TModel>(Mapper.Map(entity, model));
        }

        public virtual EmptyResponse Delete(Guid id)
        {
            var response = new EmptyResponse();
            var company = _repository.GetById(id);
            if (company == null)
            {
                response.Errors.Add(new ErrorObject(new string[0], "Can't find company", ErrorType.NotFound));
                return response;
            }
            _repository.Delete(company);
            _untOfWork.SaveChanges();
            return new EmptyResponse();
        }

        public virtual SingleEntityResponse<TModel> Update(TModel data)
        {
            if (!data.Id.HasValue)
                return new SingleEntityResponse<TModel>(null);

            var existingItem = _repository.GetById(data.Id.Value);
            var model = Mapper.Map(data, existingItem);
            
            return new SingleEntityResponse<TModel>(Mapper.Map(existingItem, data));
        }

        public virtual SingleEntityResponse<TModel> Get(Guid? id)
        {
            if (!id.HasValue)
                return new SingleEntityResponse<TModel>(null);

            var entity = _repository.GetById(id.Value);
            if (entity == null)
                return new SingleEntityResponse<TModel>(null);

            var model = Mapper.Map(entity, Activator.CreateInstance<TModel>());

            return new SingleEntityResponse<TModel>(model);
        }

        public ListResponse<TModel> Get()
        {
            return new ListResponse<TModel>(_repository.GetAll().Select(x => Mapper.Map(x, Activator.CreateInstance<TModel>())));
        }
    }
}
