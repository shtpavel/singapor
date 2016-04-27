using System.Linq;
using FluentValidation;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Company;
using Singapor.Services.Responses;
using Singapor.Services.Events;
using Singapor.Services.Events.Models;

namespace Singapor.Services.Services
{
	public class CompanyService : BaseService<CompanyModel, Company>, ICompanyService
	{
		#region Fields

		private readonly IEventAggregatorProvider _eventAggregatorProvider;

		#endregion

		#region Constructors

		public CompanyService(
			IUnitOfWork unitOfWork,
            ITranslationsService translationsService,
			IRepository<Company> repository,
            IEventAggregatorProvider eventAggregatorProvider) : base(unitOfWork, translationsService, repository)
		{
            _eventAggregatorProvider = eventAggregatorProvider;
		}

		#endregion

		#region Public methods

		public override SingleEntityResponse<CompanyModel> Create(CompanyModel model)
		{
			var newCopmanyValidator = new NewCompanyValidator(_repository, _translationsService);
			var validationResult = newCopmanyValidator.Validate(model);
			if (!validationResult.IsValid)
				return new SingleEntityResponse<CompanyModel>(model, validationResult.GetErrorsObjects().ToList());

			var response = base.Create(model);

			if (response.IsValid)
			{
                _eventAggregatorProvider.GetEventAggregator().SendMessage(new CompanyCreated(model));
                //TODO: handle somehow the fact that user creation failed.
            }

			return response;
		}

		#endregion
	}
}