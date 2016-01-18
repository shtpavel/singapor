using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;
using Singapor.Services.Responses;

namespace Singapor.Api.Classes
{
    public class Response<T> where T: ModelBase
    {
        public Response(T data, IEnumerable<ErrorObject> errors)
        {
            Data = data;
            Errors = errors;
        }
        public T Data { get; private set; }
        public IEnumerable<ErrorObject> Errors { get; private set; }
    }
}
