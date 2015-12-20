using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;

namespace Singapor.Services.Responses
{
    public class ListResponse<T> : ResponseBase where T : ModelBase
    {
        public ListResponse(IEnumerable<SingleEntityResponse<T>> data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        public IEnumerable<SingleEntityResponse<T>> Data { get; private set; }
    }
}
