using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Resources;
using System.Linq;
using Singapor.Helpers;

namespace Singapor.Tests.Tests
{
	[TestClass]
	public class UnitTypeTests : UnitTestBase
	{
		#region Public methods

		[TestMethod]
		public void Can_create_unit_type()
		{
			var companyModel = CreateCompany();
			var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);

            var response = _unitTypeService.Create(unitTypeModel);

			Assert.IsTrue(response.IsValid);
            Assert.IsNotNull(response.Data.CompanyId);
		}

        [TestMethod]
        public void Can_create_unit_type_with_empty_description()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);
            unitTypeModel.Description = null;
            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsTrue(response.IsValid);
            Assert.IsNotNull(response.Data.CompanyId);
        }

        [TestMethod]
        public void Can_not_create_unit_type_without_companyId()
        {
            var unitTypeModel = _unitTypeModelGenerator.Get();
            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
        }

        [TestMethod]
        public void Can_not_create_unit_type_without_name()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);
            unitTypeModel.Name = null;
            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
        }

        [TestMethod]
        public void Can_not_create_unit_type_without_invalid_name_lenth()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);
            unitTypeModel.Name = StringsGenerators.GenerateString(105);
            var response = _unitTypeService.Create(unitTypeModel);

            Assert.IsFalse(response.IsValid);
            AssertValidationErrorIsInList(string.Format(Validation.LessThan, 100), response);
        }

        [TestInitialize]
		public override void Setup()
		{
			base.Setup();
		}

		#endregion
	}
}