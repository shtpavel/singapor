using Singapor.Helpers;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators.Unit
{
	internal class UnitTypeModelGenerator : IUnitTypeModelGenerator
	{
        #region Public methods

        public UnitTypeModel Get()
		{
			var model = new UnitTypeModel();
			model.Description = StringsGenerators.GenerateString(199);
			model.Name = StringsGenerators.GenerateString(10);

			return model;
		}

		public UnitTypeModel Get(CompanyModel companyModel)
		{
			var model = Get();
			model.CompanyId = companyModel.Id;

			return model;
		}

		#endregion
	}
}