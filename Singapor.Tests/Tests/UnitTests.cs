using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Texts;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UnitTests : UnitTestBase
    {
        #region Public methods

        [TestMethod]
        public void Can_creat_unit()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);

            var model = _unitModelGenerator.Get(companyModel, unitTypeModel);

            var response = _unitService.Create(model);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_create_child_unit_for_container_unit()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);

            var model = _unitModelGenerator.Get(companyModel, unitTypeModel);
            model.IsContainer = true;
            var response = _unitService.Create(model);

            var childModel = _unitModelGenerator.Get(companyModel, unitTypeModel);
            childModel.ParentUnitId = response.Data.Id;

            var childResponse = _unitService.Create(childModel);

            Assert.IsTrue(childResponse.IsValid);
        }

        [TestMethod, Ignore]
        public void Can_create_multiple_units_at_one_time()
        {
            var models = new List<UnitModel>();
            for (var i = 0; i < new Random().Next(10, 20); i++)
            {
                models.Add(_unitModelGenerator.Get());
            }

            var response = _unitService.Create(models);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_not_create_child_unit_for_non_container_unit()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);

            var model = _unitModelGenerator.Get(companyModel, unitTypeModel);
            var response = _unitService.Create(model);

            var childModel = _unitModelGenerator.Get(companyModel, unitTypeModel);
            childModel.ParentUnitId = response.Data.Id;

            var childResponse = _unitService.Create(childModel);

            Assert.IsFalse(childResponse.IsValid);
            Assert.IsTrue(childResponse.Errors.Any(x =>
                x.Fields.Any(f => f.Equals("ParentUnitId", StringComparison.InvariantCultureIgnoreCase))
                && x.Message.Equals(Validation.ParentUnitIsNotContainer, StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestMethod, Ignore]
        public void Can_not_create_more_than_20_units_at_one_time()
        {
            var models = new List<UnitModel>();
            for (var i = 0; i < new Random().Next(21, 80); i++)
            {
                models.Add(_unitModelGenerator.Get());
            }

            var response = _unitService.Create(models);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.CantCreateMuchUnitsAtOneTime));
        }

        [TestMethod]
        public void Can_not_create_unit_with_wrong_parent_unit_id()
        {
            var model = _unitModelGenerator.Get();
            model.ParentUnitId = Guid.NewGuid();

            var response = _unitService.Create(model);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x =>
                x.Fields.Any(f => f.Equals("ParentUnitId", StringComparison.InvariantCultureIgnoreCase))
                && x.Message.Equals(Validation.UnitNotFound, StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestMethod]
        public void Can_not_create_unit_without_company_id()
        {
            var model = _unitModelGenerator.Get();

            var response = _unitService.Create(model);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x =>
                x.Fields.Any(f => f.Equals("CompanyId", StringComparison.InvariantCultureIgnoreCase))
                && x.Message.Equals(Validation.Required, StringComparison.InvariantCultureIgnoreCase)));
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion
    }
}