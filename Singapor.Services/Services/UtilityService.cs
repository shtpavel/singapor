using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Utility;
using Singapor.Services.Responses;
using Singapor.Services.Helpers;
using System.Linq;

namespace Singapor.Services.Services
{
	public class UtilityService : BaseService<UtilityModel, Utility>, IUtilityService
	{
        #region Fields

        private readonly ICompanyService _companyService;

        #endregion

        #region Constructors

        public UtilityService(
            ICompanyService companyService, 
            ITranslationsService translationsService,
            IUnitOfWork unitOfWork, 
            IRepository<Utility> repository) : base(unitOfWork, translationsService, repository)
		{
            _companyService = companyService;
        }

        #endregion

        #region Public methods

        public override SingleEntityResponse<UtilityModel> Create(UtilityModel model)
        {
            var newUtilityValidator = new NewUtilityValidator(_companyService, _translationsService);
            var validationResult = newUtilityValidator.Validate(model);
            if (!validationResult.IsValid)
                return new SingleEntityResponse<UtilityModel>(model, validationResult.GetErrorsObjects().ToList());
            return base.Create(model);
        }

        #endregion
    }
}