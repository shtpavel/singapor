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

		public NewUnitValidator(ICompanyService companyService, IUnitService unitService,
			IUnitTypeService unitTypeService) : base(companyService)
		{
			RuleFor(x => x.ParentUnitId).Must(x =>
			{
				if (x.HasValue)
				{
					var unit = unitService.Get(x.Value);
					return unit.Data != null;
				}
				return true;
			}).WithMessage(Validation.UnitNotFound);
			RuleFor(x => x.ParentUnitId).Must(x =>
			{
				if (x.HasValue)
				{
					var unit = unitService.Get(x.Value);

					if (unit.Data != null)
					{
						return unit.Data.IsContainer;
					}
				}
				return true;
			}).WithMessage(Validation.ParentUnitIsNotContainer);

			RuleFor(x => x.TypeId).NotNull().WithMessage(Validation.Required);
			RuleFor(x => x.TypeId).Must(x =>
			{
				if (x.HasValue)
				{
					var type = unitTypeService.Get(x.Value);
					return type.Data != null;
				}
				return true;
			}).WithMessage(Validation.UnitTypeNotFound);

			RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Name).Must(x => !unitService.Get(n => n.Name.Equals(x)).Data.Any())
                .WithMessage(Validation.DuplicateName);

        }

		#endregion
	}
}