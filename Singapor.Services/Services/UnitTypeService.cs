using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.UnitType;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
	public class UnitTypeService : BaseService<UnitTypeModel, UnitType>, IUnitTypeService
	{
		#region Fields

		private readonly ICompanyService _companyService;

		#endregion

		#region Constructors

		public UnitTypeService(
			ICompanyService companyService,
            ITranslationsService translationsService,
			IUnitOfWork unitOfWork,
			IRepository<UnitType> repository) : base(unitOfWork, translationsService, repository)
		{
			_companyService = companyService;
		}

		#endregion

		#region Public methods

		public override SingleEntityResponse<UnitTypeModel> Create(UnitTypeModel model)
		{
			var validator = new NewUnitTypeValidator(_translationsService, _companyService);
			var validationResult = validator.Validate(model);
			if (!validationResult.IsValid)
				return new SingleEntityResponse<UnitTypeModel>(model, validationResult.GetErrorsObjects().ToList());
			return base.Create(model);
		}

		#endregion
	}
}