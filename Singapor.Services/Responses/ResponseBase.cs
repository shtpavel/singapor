using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Responses
{
    public class ResponseBase
    {
        protected ResponseBase(List<ErrorObject> errors)
        {
            Errors = errors;
        }

        public bool IsValid { get { return Errors == null || !Errors.Any(); }}

        public List<ErrorObject> Errors { get; private set; }
    }

    public class ErrorObject
    {
        public ErrorObject(IEnumerable<string> fields, string message, ErrorType errorType)
        {
            Fields = fields;
            Message = message;
            Type = errorType;
        }

        public IEnumerable<string> Fields { get; private set; }
        public ErrorType Type { get; private set; }
        public string Message { get; private set; }
    }

    public enum ErrorType
    {
        NotFound,
        InternalError,
        Validation
    }
}
