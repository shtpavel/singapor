using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;

namespace Singapor.Services.Responses
{
    public class SingleEntityResponse<T> : ResponseBase where T : ModelBase
    {
        public SingleEntityResponse(T data, List<ErrorObject> errors = null) : base(errors)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
