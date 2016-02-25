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
    public class CompaniesController : CrudControllerBase<ICompanyService,CompanyModel>
    {
        public CompaniesController(ICompanyService service)
            : base(service)
        {
        }
    }
}
