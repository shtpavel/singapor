using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Singapor.Api.Controllers.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class AuthController : ControllerBase<CompanyModel>
    {
        private readonly ICompanyService _service;

        public AuthController(ICompanyService service)
        {
            _service = service;
        }

        public HttpResponseMessage Post(CompanyModel model)
        {
            return GetResponse(_service.Create(model), HttpStatusCode.Created);
        }
    }
}
