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
    public class UnitModelGenerator : IGenerator<UnitModel>
    {
        private readonly ICompanyService _companyService;
        private readonly IUnitTypeService _unitTypeService;

        public UnitModelGenerator(ICompanyService companyService, IUnitTypeService unitTypeService)
        {
            _companyService = companyService;
            _unitTypeService = unitTypeService;
        }

        public UnitModel Get()
        {
            var model = new UnitModel();
            model.Description = StringsGenerators.GenerateString(199);
            model.IsParent = false;
            model.Name = StringsGenerators.GenerateString(10);
            var companyModel = _companyService.Get().Data.FirstOrDefault();
            if (companyModel != null)
                model.CompanyId = companyModel.Id;

            var unitTypeModel = _unitTypeService.Get().Data.FirstOrDefault();
            if (unitTypeModel != null)
                model.TypeId = unitTypeModel.Id;

            return model;
        }
    }
}
