using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Company
{
	public class NewCompanyValidator : AbstractValidator<CompanyModel>
	{
		#region Fields

		private readonly IRepository<Model.Entities.Company> _companyRepository;

		#endregion

		#region Constructors

		public NewCompanyValidator(IRepository<Model.Entities.Company> companyRepository)
		{
			_companyRepository = companyRepository;
			CascadeMode = CascadeMode.StopOnFirstFailure;

			RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
			RuleFor(x => x.Name).Length(6, 20).WithMessage(string.Format(Validation.LengthBetween, 6, 20));

			RuleFor(x => x.Phone).NotEmpty().WithMessage(Validation.Required);
			RuleFor(x => x.Country).NotEmpty().WithMessage(Validation.Required);

			RuleFor(x => x.Email).NotEmpty().WithMessage(Validation.Required);
			RuleFor(x => x.Email)
				.Must(x => new EmailAddressAttribute().IsValid(x))
				.WithMessage(Validation.EmailIsNotValid);
			RuleFor(x => x.Email)
				.Must(email => !_companyRepository.GetAll(cmp => cmp.Email == email).Any())
				.WithMessage(Validation.DuplicateEmail);
		}

		#endregion
	}
}