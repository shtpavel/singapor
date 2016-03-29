using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
	public class UnitTypesController : CrudControllerBase<IUnitTypeService, UnitTypeModel>
	{
		#region Constructors

		public UnitTypesController(IUnitTypeService service)
			: base(service)
		{
		}

		#endregion
	}
}