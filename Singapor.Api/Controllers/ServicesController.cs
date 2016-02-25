using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class ServicesController : CrudControllerBase<IServiceService, ServiceModel>
    {
        #region Constructors

        public ServicesController(IServiceService serviceService) : base(serviceService)
        {
        }

        #endregion
    }
}