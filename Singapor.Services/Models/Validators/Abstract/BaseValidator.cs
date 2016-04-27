using FluentValidation;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models.Validators.Abstract
{
    internal abstract class BaseValidator<T> : AbstractValidator<T> where T : ModelBase
    {
        private readonly ITranslationsService _translationsService;

        protected BaseValidator(ITranslationsService translationsService)
        {
            _translationsService = translationsService;
        }
    }
}