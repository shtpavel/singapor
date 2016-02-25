using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class ServicesController : CrudControllerBase<IServiceService,ServiceModel>
    {
        public ServicesController(IServiceService serviceService) : base(serviceService)
        {
        }

        [Route("api/companies/{companyId}/services")] //TODO: replace with odata
        public HttpResponseMessage GetByCompanyId(Guid companyId)
        {
            return GetResponse(_service.Get(x => x.CompanyId == companyId), HttpStatusCode.OK);
        }
    }
}
