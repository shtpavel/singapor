using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Responses
{
    public class SingleEntityResponse<T> : ResponseBase where T : class
    {
        public SingleEntityResponse(T data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
