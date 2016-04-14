using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Responses;
using Singapor.Texts;
using Singapor.Helpers;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UtilityTests : UnitTestBase
    {
        //public Guid? Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public Guid? CompanyId

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
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.DuplicateId));
        }

        [TestMethod]
        public void Can_not_create_utility_without_companyId()
        {
            var utilityModel = _utilityModelGenerator.Get();
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
        }

        [TestMethod]
        public void Can_not_create_utility_without_name()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Name = null;
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
        }

        [TestMethod]
        public void Can_not_create_utility_with_invalid_name_lenth()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Name = StringsGenerators.GenerateString(65);
            var response = _utilitySerivce.Create(utilityModel);

            AssertValidationErrorIsInList(string.Format(Validation.LengthBetween, 1, 60), response);
        }

        [TestMethod]
        public void Can_not_create_utility_with_invalid_description_lenth()
        {
            var companyModel = CreateCompany();
            var utilityModel = _utilityModelGenerator.Get(companyModel);
            utilityModel.Description = StringsGenerators.GenerateString(205);
            var response = _utilitySerivce.Create(utilityModel);

            Assert.IsFalse(response.IsValid);
            AssertValidationErrorIsInList(string.Format(Validation.LessThan, 200), response);
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion
    }
}
