using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;
using Singapor.Resources;

namespace Singapor.Services.Models.Validators.UnitType
{
	internal class NewUnitTypeValidator : CompanyDependentValidatorBase<UnitTypeModel>
	{
		#region Constructors

		public NewUnitTypeValidator(
            ITranslationsService translationsService,
            ICompanyService companyService) : base(companyService, translationsService)
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
            RuleFor(x => x.Name).Length(1, 100).WithMessage(string.Format(translationsService.GetTranslationByKey("validations.lessThan"), 100));
		}

		#endregion
	}
}