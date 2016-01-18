using System.ComponentModel.DataAnnotations;
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
            RuleFor(x => x.Email).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Country).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Email)
                .Must(x => new EmailAddressAttribute().IsValid(x))
                .WithMessage(Validation.EmailIsNotValid);
        }

        #endregion
    }
}