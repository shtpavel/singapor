using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Company;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
	public class CompanyService : BaseService<CompanyModel, Company>, ICompanyService
	{
		#region Fields

		private readonly IUserService _userService;

		#endregion

		#region Constructors

		public CompanyService(
			IUnitOfWork unitOfWork,
			IRepository<Company> repository,
			IUserService userService) : base(unitOfWork, repository)
		{
			_userService = userService;
		}

		#endregion

		#region Public methods

		public override SingleEntityResponse<CompanyModel> Create(CompanyModel model)
		{
			var newCopmanyValidator = new NewCompanyValidator(_repository);
			var validationResult = newCopmanyValidator.Validate(model);
			if (!validationResult.IsValid)
				return new SingleEntityResponse<CompanyModel>(model, validationResult.GetErrorsObjects().ToList());

			var response = base.Create(model);

			if (response.IsValid)
			{
				var userCreationResponse = _userService.Create(model.Id.Value, model.Email);
				//TODO: handle somehow the fact that user creation failed.
			}

			return response;
		}

		#endregion
	}
}