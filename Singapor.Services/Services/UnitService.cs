using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Unit;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
	public class UnitService : BaseService<UnitModel, Unit>, IUnitService
	{
		#region Fields

		private readonly ICompanyService _companyService;
		private readonly IUnitTypeService _unitTypeService;

		#endregion

		#region Constructors

		public UnitService(
			IUnitOfWork unitOfWork,
			IRepository<Unit> repository,
			ICompanyService companyService,
			IUnitTypeService unitTypeService) : base(unitOfWork, repository)
		{
			_companyService = companyService;
			_unitTypeService = unitTypeService;
		}

		#endregion

		#region Public methods

		public override SingleEntityResponse<UnitModel> Create(UnitModel model)
		{
			var newUnitValidator = new NewUnitValidator(_companyService, this, _unitTypeService);
			var validationResult = newUnitValidator.Validate(model);
			if (!validationResult.IsValid)
				return new SingleEntityResponse<UnitModel>(model, validationResult.GetErrorsObjects().ToList());
			return base.Create(model);
		}

		public override ListEntityResponse<UnitModel> Create(IEnumerable<UnitModel> models)
		{
            var newUnitValidator = new NewUnitValidator(_companyService, this, _unitTypeService);
            var responses = new List<SingleEntityResponse<UnitModel>>();
            foreach (var model in models)
            {
                var validationResult = newUnitValidator.Validate(model);
                if (!validationResult.IsValid)
                    responses.Add(new SingleEntityResponse<UnitModel>(model, validationResult.GetErrorsObjects().ToList()));
            }
            if(!responses.All(r => r.Errors == null)) return new ListEntityResponse<UnitModel>(responses);

            return base.Create(models);
		}

		#endregion
	}
}