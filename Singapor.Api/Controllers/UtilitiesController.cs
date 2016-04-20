using Singapor.Api.Controllers.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
	public class UtilitiesController : CrudControllerBase<IUtilityService, UtilityModel>
	{
		#region Constructors

		public UtilitiesController(IUtilityService utilityService) : base(utilityService)
		{
		}

		#endregion
	}
}