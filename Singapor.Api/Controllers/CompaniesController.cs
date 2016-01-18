using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public HttpResponseMessage Get()
        {
            return GetResponse(_companyService.Get(), HttpStatusCode.OK);
        }

        public HttpResponseMessage Get(Guid id)
        {
            return GetResponse(_companyService.Get(id), HttpStatusCode.Found);
        }

        public HttpResponseMessage Post(CompanyModel model)
        {
            return GetResponse(_companyService.Create(model), HttpStatusCode.Created);
        }
    }
}
