using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
	public interface IUnitTypeModelGenerator : IGenerator<UnitTypeModel>
	{
		#region Public methods

		UnitTypeModel Get(CompanyModel companyModel);

		#endregion
	}
}