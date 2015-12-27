using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Model.Entities;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UnitTypeTests : UnitTestBase
    {
        #region Public methods

        [TestMethod]
        public void Can_create_unit_type_with_fields()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);

            unitTypeModel.Fields.Add(_fieldGenerator.Get(unitTypeModel, FieldType.Integer));

            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_create_unit_type_without_fields()
        {
            var companyModel = _companyGenerator.Get();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);

            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsTrue(response.IsValid);
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion
    }
}