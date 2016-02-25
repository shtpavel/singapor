using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Singapor.Api.Classes;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Api.Controllers
{
    public class ControllerBase<TService, TModel> : ApiController
        where TService : IService<TModel>
        where TModel : ModelBase
    {
        protected TService _service;

        public ControllerBase(TService service)
        {
            _service = service;
        }

        protected HttpResponseMessage GetResponse(
            SingleEntityResponse<TModel> serviceResponse, 
            HttpStatusCode succesStatusCode)
        {
            if (serviceResponse.IsValid)
            {
                return Request.CreateResponse(
                    succesStatusCode,
                    new Response<TModel>(serviceResponse.Data, null));
            }

            return Request.CreateResponse(
                HttpStatusCode.BadRequest,
                new Response<TModel>(serviceResponse.Data, serviceResponse.Errors));
        }

        protected HttpResponseMessage GetResponse(
            ListEntityResponse<TModel> serviceResponse, 
            HttpStatusCode succesStatusCode)
        {
            HttpResponseMessage response;
            if (serviceResponse.IsValid)
            {
                response = Request.CreateResponse(
                    succesStatusCode,
                    serviceResponse.Data.Select(x => new Response<TModel>(x.Data, null)));
            }
            else
            {
                response = Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    serviceResponse.Data.Select(x => new Response<TModel>(x.Data, x.Errors)));
            }
            
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/json");
            return response;
        }

        protected ListEntityResponse<CompanyModel> Filter(ListEntityResponse<CompanyModel> listReponse, Filter filter)
        {
            return listReponse;
        }
    }
}
