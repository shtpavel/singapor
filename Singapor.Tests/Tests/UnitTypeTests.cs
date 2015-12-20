using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators;
using Unity;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UnitTypeTests : UnitTestBase
    {
        private IGenerator<CompanyModel> _companyGenerator;
        private ICompanyService _companyService;
        private IGenerator<UnitTypeModel> _unitTypeGenerator;

        [TestInitialize]
        public void Setup()
        {
            _companyGenerator = _container.Resolve<IGenerator<CompanyModel>>();
            _unitTypeGenerator = _container.Resolve<IGenerator<UnitTypeModel>>();
            _companyService = _container.Resolve<ICompanyService>();
        }

        [TestMethod]
        public void Can_create_unit_type_without_fields()
        {
        }
    }
}
