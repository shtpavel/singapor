using FluentValidation;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Company
{
    public class NewCompanyValidator : AbstractValidator<CompanyModel>
    {
        #region Constructors

        public NewCompanyValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Name).Length(6, 20).WithMessage(string.Format(Validation.LengthBetween, 6, 20));
        }

        #endregion
    }
}