using System.Collections.Generic;
using Singapor.Services.Abstract;

namespace Singapor.Services.Responses
{
    public class SingleEntityResponse<T> : ResponseBase where T : ModelBase
    {
        #region Properties

        public T Data { get; private set; }

        #endregion

        #region Constructors

        public SingleEntityResponse(T data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        #endregion
    }
}