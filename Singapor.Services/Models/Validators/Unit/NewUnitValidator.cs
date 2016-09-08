using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;
using Singapor.Resources;
using System.Linq;

namespace Singapor.Services.Models.Validators.Unit
{
	internal class NewUnitValidator : CompanyDependentValidatorBase<UnitModel>
	{
		#region Constructors

		public NewUnitValidator(
            ICompanyService companyService, 
            ITranslationsService translationsService,
            IUnitService unitService,
			IUnitTypeService unitTypeService) : base(companyService, translationsService)
		{
			RuleFor(x => x.TypeId).NotNull().WithMessage(translationsService.GetTranslationByKey("validations.required"));
			RuleFor(x => x.TypeId).Must(x =>
			{
				if (x.HasValue)
				{
					var type = unitTypeService.Get(x.Value);
					return type.Data != null;
				}
				return true;
			}).WithMessage(translationsService.GetTranslationByKey("validations.unitTypeNotFound"));

			RuleFor(x => x.Name).NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
            RuleFor(x => x.Name).Must(x => !unitService.Get(n => n.Name.Equals(x)).Data.Any())
                .WithMessage(translationsService.GetTranslationByKey("validations.duplicateName"));

        }

		#endregion
	}
}