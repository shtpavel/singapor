using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Resources;

namespace Singapor.Services.Models.Validators.Abstract
{
	internal class CompanyDependentValidatorBase<T>
		: BaseValidator<T> where T: CompanyDependentModelBase
	{
		#region Constructors

		protected CompanyDependentValidatorBase(
            ICompanyService companyService, 
            ITranslationsService translationsService) : base(translationsService)
		{
			RuleFor(x => x.CompanyId).NotNull().WithMessage(translationsService.GetTranslationByKey("validations.required"));
			RuleFor(x => x.CompanyId).Must(x =>
			{
				if (x.HasValue)
				{
					var company = companyService.Get(x.Value);
					return company.Data != null;
				}
				return true;
			}).WithMessage(translationsService.GetTranslationByKey("validations.companyNotFound"));
		}

		#endregion
	}
}