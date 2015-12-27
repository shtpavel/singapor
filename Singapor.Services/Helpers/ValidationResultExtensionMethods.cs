using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Singapor.Services.Responses;

namespace Singapor.Services.Helpers
{
    public static class ValidationResultExtensionMethods
    {
        #region Public methods

        public static IEnumerable<ErrorObject> GetErrorsObjects(this ValidationResult validationResult)
        {
            var errors =
                validationResult.
                    Errors
                    .Select(
                        x => new ErrorObject(
                            new List<string> {x.PropertyName},
                            x.ErrorMessage,
                            ErrorType.Validation));

            return errors;
        }

        #endregion
    }
}