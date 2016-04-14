using Singapor.Services.Models;
using Singapor.Helpers;
using System;

namespace Singapor.Tests.Generators.Unit
{
    public class UtilityModelGenerator : IUtilityModelGenerator
    {
        public UtilityModel Get()
        {
            return new UtilityModel()
            {
                Name = StringsGenerators.GenerateString(10),
                Description = StringsGenerators.GenerateString(60),
            };
        }

        public UtilityModel Get(CompanyModel companyModel)
        {
            var model = Get();
            model.CompanyId = companyModel.Id;
            return model;
        }
    }
}
