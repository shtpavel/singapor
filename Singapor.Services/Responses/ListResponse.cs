using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Responses
{
    public class ListResponse<T> : ResponseBase
    {
        public ListResponse(IEnumerable<T> data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; private set; }
    }
}
