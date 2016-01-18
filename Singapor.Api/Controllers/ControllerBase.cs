using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Singapor.Api.Classes;
using Singapor.Services.Abstract;
using Singapor.Services.Responses;

namespace Singapor.Api.Controllers
{
    public class ControllerBase : ApiController
    {
        public HttpResponseMessage GetResponse<T>(
            SingleEntityResponse<T> serviceResponse, 
            HttpStatusCode succesStatusCode) where T: ModelBase
        {
            if (serviceResponse.IsValid)
            {
                return Request.CreateResponse(
                    succesStatusCode, 
                    new Response<T>(serviceResponse.Data, null));
            }

            return Request.CreateResponse(
                succesStatusCode,
                new Response<T>(serviceResponse.Data, serviceResponse.Errors));
        }

        public HttpResponseMessage GetResponse<T>(
            ListEntityResponse<T> serviceResponse, 
            HttpStatusCode succesStatusCode) where T: ModelBase
        {
            HttpResponseMessage response;
            if (serviceResponse.IsValid)
            {
                response = Request.CreateResponse(
                    succesStatusCode,
                    serviceResponse.Data.Select(x => new Response<T>(x.Data, null)));
            }
            else
            {
                response = Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    serviceResponse.Data.Select(x => new Response<T>(x.Data, x.Errors)));
            }
            
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
            return response;
        }
    }
}
