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
    public class ServicesController : ControllerBase<IServiceService,ServiceModel>
    {
        public ServicesController(IServiceService serviceService) : base(serviceService)
        {
        }

        public HttpResponseMessage Get()
        {
            return GetResponse(_service.Get(), HttpStatusCode.OK);
        }

        [Route("api/companies/{companyId}/services")]
        public HttpResponseMessage GetByCompanyId(Guid companyId)
        {
            return GetResponse(_service.Get(x => x.CompanyId == companyId), HttpStatusCode.OK);
        }

        public HttpResponseMessage Get(Guid id)
        {
            return GetResponse(_service.Get(id), HttpStatusCode.Found);
        }

        [Authorize]
        public HttpResponseMessage Post(ServiceModel model)
        {
            return GetResponse(_service.Create(model), HttpStatusCode.Created);
        }
    }
}
