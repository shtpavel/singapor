using Singapor.Helpers;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators.Unit
{
	public class UnitModelGenerator : IUnitModelGenerator
	{
		#region Public methods

		public UnitModel Get()
		{
			var model = new UnitModel();
			model.Description = StringsGenerators.GenerateString(199);
			model.Name = StringsGenerators.GenerateString(10);

			return model;
		}

		public UnitModel Get(CompanyModel companyModel)
		{
			var model = Get();
			model.CompanyId = companyModel.Id;

			return model;
		}

		public UnitModel Get(CompanyModel companyModel, UnitTypeModel unitTypeModel)
		{
			var model = Get(companyModel);
			model.TypeId = unitTypeModel.Id;

			return model;
		}

		#endregion
	}
}