using Singapor.Api.Controllers.Abstract;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
	public class CompaniesController : CrudControllerBase<ICompanyService, CompanyModel>
	{
		#region Constructors

		public CompaniesController(ICompanyService service)
			: base(service)
		{
		}

		#endregion
	}
}