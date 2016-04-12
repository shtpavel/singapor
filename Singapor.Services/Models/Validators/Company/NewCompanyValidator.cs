using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Texts;
using System.Globalization;

namespace Singapor.Services.Models.Validators.Company
{
	public class NewCompanyValidator : AbstractValidator<CompanyModel>
	{
		#region Fields


		#endregion

		#region Constructors

		public NewCompanyValidator(IRepository<Model.Entities.Company> companyRepository)
		{
			CascadeMode = CascadeMode.StopOnFirstFailure;

			RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
			RuleFor(x => x.Name).Length(6, 60).WithMessage(string.Format(Validation.LengthBetween, 6, 60));
            RuleFor(x => x.Name).Must(x => !companyRepository.GetAll(n => n.Name.Equals(x)).Any())
                .WithMessage(Validation.DuplicateName);

            RuleFor(x => x.Phone).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Phone).Must(x => new PhoneAttribute().IsValid(x)).WithMessage(Validation.InvalidPhone);
            RuleFor(x => x.Phone).Must(x => !companyRepository.GetAll(n => n.Phone.Equals(x)).Any())
                .WithMessage(Validation.DuplicatePhone);

            RuleFor(x => x.Country).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Country).Must(x =>
            {
                try { return x == new RegionInfo(x).TwoLetterISORegionName; }
                catch { return false; }
            }
            ).WithMessage(Validation.InvalidCountryCode);

			RuleFor(x => x.Email).NotEmpty().WithMessage(Validation.Required);
			RuleFor(x => x.Email)
				.Must(x => new EmailAddressAttribute().IsValid(x))
				.WithMessage(Validation.InvalidEmail);
			RuleFor(x => x.Email)
				.Must(email => !companyRepository.GetAll(cmp => cmp.Email == email).Any())
				.WithMessage(Validation.DuplicateEmail);
		}

		#endregion
	}
}