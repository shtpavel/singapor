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
            IUnitTypeService unitTypeService,
            ICompanyService companyService) : base(companyService)
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Name).Length(1, 100).WithMessage(string.Format(Validation.LessThan, 100));
		}

		#endregion
	}
}