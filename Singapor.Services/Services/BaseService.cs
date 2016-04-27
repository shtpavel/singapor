using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model;
using Singapor.Model.Entities.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Responses;
using Singapor.Resources;
using Singapor.Services.Models.Validators;

namespace Singapor.Services.Services
{
	public class BaseService<TModel, TEntity> : IService<TModel>
		where TModel : ModelBase
		where TEntity : EntityBase
	{
		#region Fields

		protected readonly IRepository<TEntity> _repository;
		protected readonly IUnitOfWork _unitOfWork;
	    protected readonly ITranslationsService _translationsService;

	    #endregion

		#region Constructors

		public BaseService(
			IUnitOfWork unitOfWork,
            ITranslationsService translationsService,
			IRepository<TEntity> repository)
		{
			_unitOfWork = unitOfWork;
		    _translationsService = translationsService;
		    _repository = repository;
		}

		#endregion

		#region Public methods

		public virtual SingleEntityResponse<TModel> Create(TModel model)
		{
			if (model.Id == null || model.Id == Guid.Empty)
				model.Id = Guid.NewGuid();
			var data = Mapper.Map(model, Activator.CreateInstance<TEntity>());

			var validationResult = new CommonValidator<TModel>(this, _translationsService).Validate(model);
			if (!validationResult.IsValid)
				return new SingleEntityResponse<TModel>(model, validationResult.GetErrorsObjects().ToList());

			var entity = _repository.Add(data);
			_unitOfWork.SaveChanges();
			return new SingleEntityResponse<TModel>(Mapper.Map(entity, model));
		}

        public virtual ListEntityResponse<TModel> Create(IEnumerable<TModel> models)
        {
            var responses = new List<SingleEntityResponse<TModel>>();
            foreach (var model in models)
            {
                if (model.Id == null || model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();
                var data = Mapper.Map(model, Activator.CreateInstance<TEntity>());
                var validationResult = new CommonValidator<TModel>(this, _translationsService).Validate(model);
                if (!validationResult.IsValid)
                    responses.Add(new SingleEntityResponse<TModel>(model, validationResult.GetErrorsObjects().ToList()));
                else
                    responses.Add(new SingleEntityResponse<TModel>(Mapper.Map(_repository.Add(data), model)));
            }

            if (responses.Any(r => r.Errors != null))
                return new ListEntityResponse<TModel>(responses);

            _unitOfWork.SaveChanges(); 
            return new ListEntityResponse<TModel>(responses);
        }

        public virtual EmptyResponse Delete(Guid id)
		{
			var response = new EmptyResponse();
			var entity = _repository.GetById(id);
			if (entity == null)
			{
				response.Errors.Add(new ErrorObject(new string[0], _translationsService.GetTranslationByKey("validations.companyNotFound"), ErrorType.NotFound));
				return response;
			}

			var companyDependentEntity = (entity as CompanyDependentEntityBase);
			if (companyDependentEntity != null)
				(entity as CompanyDependentEntityBase).IsDeleted = true;
			else
				_repository.Delete(entity);

			_unitOfWork.SaveChanges();
			return new EmptyResponse();
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

		public ListEntityResponse<TModel> Get()
		{
			return
				new ListEntityResponse<TModel>(
					_repository.GetAll()
						.Select(x => new SingleEntityResponse<TModel>(Mapper.Map(x, Activator.CreateInstance<TModel>()))));
		}

		public ListEntityResponse<TModel> Get(Func<TModel, bool> predicate)
		{
			return
				new ListEntityResponse<TModel>(
					_repository
						.GetAll()
						.Select(x => Mapper.Map(x, Activator.CreateInstance<TModel>()))
						.Where(predicate)
						.Select(x => new SingleEntityResponse<TModel>(x)));
		}

		public virtual SingleEntityResponse<TModel> Update(TModel data)
		{
			if (!data.Id.HasValue)
				return new SingleEntityResponse<TModel>(null);

			var existingItem = _repository.GetById(data.Id.Value);

			return new SingleEntityResponse<TModel>(Mapper.Map(existingItem, data));
		}

		#endregion
	}
}