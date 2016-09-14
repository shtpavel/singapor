using System.Web.Http;
using Singapor.Common.Contexts;

namespace Singapor.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly IUserContext _userContext;

        public BaseController(IUserContext userContext)
        {
            _userContext = userContext;
        }
    }
}