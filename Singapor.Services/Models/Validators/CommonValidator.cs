using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Resources;
using Singapor.Services.Models.Validators.Abstract;

namespace Singapor.Services.Models.Validators
{
	internal class CommonValidator<T> : BaseValidator<T> where T : ModelBase
	{
		#region Constructors

		public CommonValidator(IService<T> service, ITranslationsService translationsService) : base(translationsService)
		{
			RuleFor(x => x.Id).NotNull().WithMessage(translationsService.GetTranslationByKey("validations.required"));

            RuleFor(x => x.Id).Must(x =>
			{
				if (x.HasValue)
				{
					return service.Get(x.Value).Data == null;
				}
				return true;
			}).WithMessage(translationsService.GetTranslationByKey("validations.duplicateId"));
        }

		#endregion
	}
}