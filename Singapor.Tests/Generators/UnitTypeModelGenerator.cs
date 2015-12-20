using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators.Helpers;

namespace Singapor.Tests.Generators
{
    internal class UnitTypeModelGenerator : IGenerator<UnitTypeModel>
    {
        private readonly ICompanyService _companyService;

        public UnitTypeModelGenerator(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public UnitTypeModel Get()
        {
            var model = new UnitTypeModel();
            model.Description = StringsGenerators.GenerateString(199);
            model.Name = StringsGenerators.GenerateString(10);
            var companyModel = _companyService.Get().Data.FirstOrDefault();
            if (companyModel != null)
                model.CompanyId = companyModel.Id.Value;

            return model;
        }

    }
}
