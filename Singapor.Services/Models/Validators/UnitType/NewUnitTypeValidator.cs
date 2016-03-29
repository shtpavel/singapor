using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.UnitType
{
	internal class NewUnitTypeValidator : CompanyDependentValidatorBase<UnitTypeModel>
	{
		#region Constructors

		public NewUnitTypeValidator(
			ICompanyService companyService,
			IUnitTypeService unitTypeService) : base(companyService)
		{
			RuleFor(x => x.Name).NotNull().WithMessage(Validation.Required);
		}

		#endregion
	}
}