using FluentValidation;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators
{
	public class CommonValidator<T> : AbstractValidator<T> where T : ModelBase
	{
		#region Constructors

		public CommonValidator(IService<T> service)
		{
			RuleFor(x => x.Id).NotNull().WithMessage(Validation.Required);
			RuleFor(x => x.Id).Must(x =>
			{
				if (x.HasValue)
				{
					return service.Get(x.Value).Data == null;
				}
				return true;
			}).WithMessage(Validation.UniqueId);
		}

		#endregion
	}
}