using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Responses;
using Singapor.Resources;
using Singapor.Helpers;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UtilityTests : UnitTestBase
    {
        #region Public methods

        [TestMethod]
        public void Can_create_utility_for_company()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);

            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsTrue(response.IsValid);
            Assert.IsNotNull(response.Data.CompanyId);
            Assert.IsNotNull(response.Data.Name);
            Assert.IsNotNull(response.Data.Description);
        }

        [TestMethod]
        public void Can_not_create_utility_with_duplicate_Id()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            var response = _utilitySerivce.Create(utilityModel);
            response.Data.Name = StringsGenerators.GenerateString(10);
            response.Data.Description = StringsGenerators.GenerateString(20);
            response = _utilitySerivce.Create(response.Data);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == _translationsService.GetTranslationByKey("validations.duplicateId")));
        }

        [TestMethod]
        public void Can_not_create_utility_without_companyId()
        {
            var utilityModel = _utilityModelGenerator.Get();
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == _translationsService.GetTranslationByKey("validations.required")));
        }

        [TestMethod]
        public void Can_not_create_utility_without_name()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Name = null;
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == _translationsService.GetTranslationByKey("validations.required")));
        }

        [TestMethod]
        public void Can_not_create_utility_with_invalid_name_lenth()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Name = StringsGenerators.GenerateString(65);
            var response = _utilitySerivce.Create(utilityModel);

            AssertValidationErrorIsInList(string.Format(_translationsService.GetTranslationByKey("validations.lengthBetween"), 1, 60), response);
        }

        [TestMethod]
        public void Can_not_create_utility_with_invalid_description_lenth()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Description = StringsGenerators.GenerateString(205);
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            AssertValidationErrorIsInList(string.Format(_translationsService.GetTranslationByKey("validations.lessThan"), 200), response);
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion
    }
}
