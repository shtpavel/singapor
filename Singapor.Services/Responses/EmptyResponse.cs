using System.Collections.Generic;

namespace Singapor.Services.Responses
{
    public class EmptyResponse : ResponseBase
    {
        public EmptyResponse(List<ErrorObject> errors = null) : base(errors)
        {
        }
    }
}