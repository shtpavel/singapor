using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Resources;
using System.Globalization;
using Singapor.Services.Abstract;
using Singapor.Services.Models.Validators.Abstract;

namespace Singapor.Services.Models.Validators.Company
{
	internal class NewCompanyValidator : BaseValidator<CompanyModel>
	{
		#region Fields


		#endregion

		#region Constructors

		public NewCompanyValidator(IRepository<Model.Entities.Company> companyRepository, ITranslationsService translationsService) : base(translationsService)
		{
			CascadeMode = CascadeMode.StopOnFirstFailure;

			RuleFor(x => x.Name).NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
			RuleFor(x => x.Name).Length(6, 60).WithMessage(string.Format(translationsService.GetTranslationByKey("validations.lengthBetween"), 6, 60));
            RuleFor(x => x.Name).Must(x => !companyRepository.GetAll(n => n.Name.Equals(x)).Any())
                .WithMessage(translationsService.GetTranslationByKey("validations.duplicateName"));

            RuleFor(x => x.Phone).NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
            RuleFor(x => x.Phone).Must(x => new PhoneAttribute().IsValid(x)).WithMessage(translationsService.GetTranslationByKey("validations.invalidPhone"));
            RuleFor(x => x.Phone).Must(x => !companyRepository.GetAll(n => n.Phone.Equals(x)).Any())
                .WithMessage(translationsService.GetTranslationByKey("validations.duplicatePhone"));

            RuleFor(x => x.Country).NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
            RuleFor(x => x.Country).Must(x =>
            {
	            return new CountriesProvider().Countries.Any(y => y.Code == x);
            }
            ).WithMessage(translationsService.GetTranslationByKey("validations.invalidCountryCode"));

			RuleFor(x => x.Email).NotEmpty().WithMessage(translationsService.GetTranslationByKey("validations.required"));
			RuleFor(x => x.Email)
				.Must(x => new EmailAddressAttribute().IsValid(x))
				.WithMessage(translationsService.GetTranslationByKey("validations.invalidEmail"));
			RuleFor(x => x.Email)
				.Must(email => !companyRepository.GetAll(cmp => cmp.Email == email).Any())
				.WithMessage(translationsService.GetTranslationByKey("validations.duplicateEmail"));
		}

		#endregion
	}
}