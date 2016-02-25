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
        #region Fields

        private readonly ICompanyService _service;

        #endregion

        #region Constructors

        public AuthController(ICompanyService service)
        {
            _service = service;
        }

        #endregion

        #region Public methods

        [HttpPost]
        public HttpResponseMessage Register(CompanyModel model)
        {
            return GetResponse(_service.Create(model), HttpStatusCode.Created);
        }

        #endregion
    }
}