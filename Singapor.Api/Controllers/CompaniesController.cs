using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Singapor.Api.Classes;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Api.Controllers
{
    public class CompaniesController : ControllerBase<ICompanyService,CompanyModel>
    {
        public CompaniesController(ICompanyService service)
            : base(service)
        {
        }

        [Authorize]
        public HttpResponseMessage Get()
        {
            return GetResponse(_service.Get(), HttpStatusCode.OK);
        }

        [Authorize]
        public HttpResponseMessage Get(Guid id)
        {
            return GetResponse(_service.Get(id), HttpStatusCode.Found);
        }

        public HttpResponseMessage Post(CompanyModel model)
        {
            return GetResponse(_service.Create(model), HttpStatusCode.Created);
        }

    }
}
