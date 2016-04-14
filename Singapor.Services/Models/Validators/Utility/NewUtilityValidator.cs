using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Utility
{
    internal class NewUtilityValidator : CompanyDependentValidatorBase<UtilityModel>
    {
        #region Fields


        #endregion

        #region Constructors

        public NewUtilityValidator(IUtilityService utilityService, ICompanyService companyService) : base(companyService)
        {
            RuleFor(x => x.Id).Must(x =>
            {
                if(x.HasValue)
                {
                    var utility = utilityService.Get(x.Value);
                    return utility.Data != null;
                }
                return true;
            }).WithMessage(Validation.DuplicateId);

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Name).Length(1, 60).WithMessage(string.Format(Validation.LengthBetween, 1, 60));

            RuleFor(x => x.Description).Length(0, 200).WithMessage(string.Format(Validation.LessThan, 200));
        }

        #endregion
    }
}
