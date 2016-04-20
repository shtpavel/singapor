using Singapor.Api.Controllers.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Singapor.Api.Controllers
{
    public class UnitsController : CrudControllerBase<IUnitService, UnitModel>
    {
        #region Constructors

        public UnitsController(IUnitService service)
            : base(service)
        {
        }

        #endregion

        #region Public methods

        [AllowAnonymous]
        public virtual HttpResponseMessage Post(IEnumerable<UnitModel> models)
        {
            return GetResponse(_service.Create(models), HttpStatusCode.Created);
        }

        #endregion
    }
}