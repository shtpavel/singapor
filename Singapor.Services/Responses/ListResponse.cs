using System.Collections.Generic;
using Singapor.Services.Abstract;

namespace Singapor.Services.Responses
{
    public class ListResponse<T> : ResponseBase where T : ModelBase
    {
        #region Properties

        public IEnumerable<SingleEntityResponse<T>> Data { get; private set; }

        #endregion

        #region Constructors

        public ListResponse(IEnumerable<SingleEntityResponse<T>> data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        #endregion
    }
}