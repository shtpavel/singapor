using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Singapor.Services.Responses;

namespace Singapor.Services.Helpers
{
    public static class ValidationResultExtensionMethods
    {
        public static IEnumerable<ErrorObject> GetErrorsObjects(this ValidationResult validationResult)
        {
            var errors =
                    validationResult.
                    Errors
                        .Select(
                            x => new ErrorObject(
                                new List<string>() { x.PropertyName },
                                x.ErrorMessage,
                                ErrorType.Validation));

            return errors;
        }
    }
}
