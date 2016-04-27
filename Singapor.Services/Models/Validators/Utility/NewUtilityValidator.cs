using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;
using Singapor.Resources;

namespace Singapor.Services.Models.Validators.Utility
{
    internal class NewUtilityValidator : CompanyDependentValidatorBase<UtilityModel>
    {
        #region Fields


        #endregion

        #region Constructors

        public NewUtilityValidator(
            ICompanyService companyService, 
            ITranslationsService translationsService) : base(companyService, translationsService)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
            RuleFor(x => x.Name).Length(1, 60).WithMessage(string.Format(translationsService.GetTranslationByKey("validations.lengthBetween"), 1, 60));

            RuleFor(x => x.Description).Length(0, 200).WithMessage(string.Format(translationsService.GetTranslationByKey("validations.lessThan"), 200));
        }

        #endregion
    }
}
