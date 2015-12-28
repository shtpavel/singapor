using System;
using System.Linq;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Model.Entities;
using Singapor.Texts;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class FieldsTests : UnitTestBase
    {
        #region Public methods

        [TestMethod]
        public void Can_create_field()
        {
            var companyModel = CreateCompany();
            var unitType = CreateUnitType(companyModel);
            var fieldModel = _fieldGenerator.Get(unitType, FieldType.Integer);

            var response = _fieldService.Create(fieldModel);
            Assert.IsTrue(response.IsValid);
        }
        
        [TestMethod]
        public void Can_create_field_with_field_validator()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);
            var fieldModel = _fieldGenerator.Get(unitTypeModel, FieldType.Integer);

            var response = _fieldService.Create(fieldModel);
            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_not_create_field_with_name_lower_then_5_letters()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);
            var fieldModel = _fieldGenerator.Get(unitTypeModel, FieldType.Integer);

            fieldModel.Name = "1234";

            var response = _fieldService.Create(fieldModel);
            AssertValidationErrorIsInList(string.Format(Validation.LengthBetween, 5, 20), response);
        }

        [TestMethod]
        public void Can_not_create_field_without_unit_type_id()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);
            var fieldModel = _fieldGenerator.Get(unitTypeModel, FieldType.Integer);

            var response = _fieldService.Create(fieldModel);
            
            AssertValidationErrorIsInList(Validation.Required, response, "UnitTypeId");
        }
        
        [TestMethod]
        public void Can_not_create_field_without_name()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);
            var fieldModel = _fieldGenerator.Get(unitTypeModel, FieldType.Integer);
            
            fieldModel.Name = String.Empty;
            var response = _fieldService.Create(fieldModel);
            
            AssertValidationErrorIsInList(Validation.Required, response, "Name");
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion
    }
}