﻿using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators.Helpers;

namespace Singapor.Tests.Generators.Unit
{
    internal class UnitTypeModelGenerator : IUnitTypeModelGenerator
    {
        #region Fields

        private readonly ICompanyService _companyService;

        #endregion

        #region Constructors

        public UnitTypeModelGenerator(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #endregion

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