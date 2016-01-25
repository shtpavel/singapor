using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class UnitTypesController : ControllerBase
    {
        private readonly IUnitTypeService _unitTypeService;

        public UnitTypesController(IUnitTypeService unitTypeService)
        {
            _unitTypeService = unitTypeService;
        }

        public HttpResponseMessage Get()
        {
            return GetResponse(_unitTypeService.Get(), HttpStatusCode.OK);
        }

        public HttpResponseMessage Get(Guid id)
        {
            return GetResponse(_unitTypeService.Get(id), HttpStatusCode.Found);
        }

        public HttpResponseMessage Post(UnitTypeModel model)
        {
            return GetResponse(_unitTypeService.Create(model), HttpStatusCode.Created);
        }
    }
}
