using Singapor.Api.Controllers.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
	public class UtilityController : CrudControllerBase<IUtilityService, UtilityModel>
	{
		#region Constructors

		public UtilityController(IUtilityService utilityService) : base(utilityService)
		{
		}

		#endregion
	}
}