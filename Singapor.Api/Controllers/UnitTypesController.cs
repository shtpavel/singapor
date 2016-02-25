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
    public class UnitTypesController : CrudControllerBase<IUnitTypeService,UnitTypeModel>
    {
        public UnitTypesController(IUnitTypeService service)
            : base(service)
        {
        }
    }
}
