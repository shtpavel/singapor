using System.Collections.Generic;

namespace Singapor.Services.Responses
{
    public class EmptyResponse : ResponseBase
    {
        #region Constructors

        public EmptyResponse(List<ErrorObject> errors = null) : base(errors)
        {
        }

        #endregion
    }
}