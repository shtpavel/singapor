using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Abstract
{
	internal class CompanyDependentValidatorBase<T>
		: AbstractValidator<T> where T : CompanyDependentModelBase
	{
		#region Constructors

		public CompanyDependentValidatorBase(ICompanyService companyService)
		{
			RuleFor(x => x.CompanyId).NotNull().WithMessage(Validation.Required);
			RuleFor(x => x.CompanyId).Must(x =>
			{
				if (x.HasValue)
				{
					var company = companyService.Get(x.Value);
					return company.Data != null;
				}
				return true;
			}).WithMessage(Validation.CompanyNotFound);
		}

		#endregion
	}
}