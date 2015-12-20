using System.Linq;
using System.Runtime.InteropServices;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators.Helpers;

namespace Singapor.Tests.Generators.Unit
{
    public class UnitModelGenerator : IUnitModelGenerator
    {
        public UnitModel Get()
        {
            var model = new UnitModel();
            model.Description = StringsGenerators.GenerateString(199);
            model.IsContainer = false;
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
    }
}
