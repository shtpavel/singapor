using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators;
using Unity;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UnitTypeTests : UnitTestBase
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestMethod]
        public void Can_create_unit_type_without_fields()
        {
            var companyModel = _companyGenerator.Get();
            var unitTypeModel = _unitTypeGenerator.Get(companyModel);

            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_create_unit_type_with_fields()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeGenerator.Get(companyModel);
            
            unitTypeModel.Fields.Add(_fieldGenerator.Get(unitTypeModel, FieldType.Integer));

            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsTrue(response.IsValid);
        }
    }
}
