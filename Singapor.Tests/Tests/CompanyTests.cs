using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Responses;
using Singapor.Resources;
using Singapor.Helpers;

namespace Singapor.Tests.Tests
{
	[TestClass]
	public class CompanyTests : UnitTestBase
	{
		#region Public methods

		[TestMethod]
		public void Can_create_company()
		{
			var companyModel = _companyGenerator.Get();
			var response = _companyService.Create(companyModel);

			Assert.IsTrue(response.IsValid);
		}

		[TestMethod]
		public void Can_not_create_company_with_duplicate_id()
		{
            var companyModel = _companyGenerator.Get();
            var response = _companyService.Create(companyModel);

            var newCompanyModel = _companyGenerator.Get();
            response.Data.Name = newCompanyModel.Name;
            response.Data.Phone = newCompanyModel.Phone;
            response.Data.Email = newCompanyModel.Email;

            response = _companyService.Create(response.Data);
            
			Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.DuplicateId));
		}

        [TestMethod]
        public void Can_not_create_company_with_duplicate_email()
        {
            var companyModel = _companyGenerator.Get();
            var response = _companyService.Create(companyModel);

            var newCompanyModel = _companyGenerator.Get();
            response.Data.Name = newCompanyModel.Name;
            response.Data.Phone = newCompanyModel.Phone;
            response.Data.Id = new System.Guid();

            response = _companyService.Create(response.Data);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.DuplicateEmail));
        }

        [TestMethod]
        public void Can_not_create_company_with_duplicate_name()
        {
            var companyModel = _companyGenerator.Get();
            var response = _companyService.Create(companyModel);

            var newCompanyModel = _companyGenerator.Get();
            response.Data.Email = newCompanyModel.Email;
            response.Data.Phone = newCompanyModel.Phone;
            response.Data.Id = new System.Guid();

            response = _companyService.Create(response.Data);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.DuplicateName));
        }

        [TestMethod]
        public void Can_not_create_company_with_duplicate_phone()
        {
            var companyModel = _companyGenerator.Get();
            var response = _companyService.Create(companyModel);

            var newCompanyModel = _companyGenerator.Get();
            response.Data.Email = newCompanyModel.Email;
            response.Data.Name = newCompanyModel.Name;
            response.Data.Id = new System.Guid();

            response = _companyService.Create(response.Data);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.DuplicatePhone));
        }

        [TestMethod]
		public void Can_not_create_company_with_empty_email()
		{
			var companyModel = _companyGenerator.Get();
			companyModel.Email = string.Empty;

			var response = _companyService.Create(companyModel);

			Assert.IsFalse(response.IsValid);
			Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Type, ErrorType.Validation);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.Count(), 1);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.First(), "Email");
		}

		[TestMethod]
		public void Can_not_create_company_with_empty_name()
		{
			var companyModel = _companyGenerator.Get();
			companyModel.Name = string.Empty;

			var response = _companyService.Create(companyModel);

			Assert.IsFalse(response.IsValid);
			Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Type, ErrorType.Validation);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.Count(), 1);
		}

		[TestMethod]
		public void Can_not_create_company_with_empty_phone()
		{
			var companyModel = _companyGenerator.Get();
			companyModel.Phone = string.Empty;

			var response = _companyService.Create(companyModel);

			Assert.IsFalse(response.IsValid);
			Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Type, ErrorType.Validation);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.Count(), 1);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.First(), "Phone");
		}

		[TestMethod]
		public void Can_not_create_company_with_invalid_name_length()
		{
			var companyModel = _companyGenerator.Get();
			companyModel.Name = StringsGenerators.GenerateString(3);

			var response = _companyService.Create(companyModel);

			AssertValidationErrorIsInList(string.Format(Validation.LengthBetween, 6, 60), response);
		}

        [TestMethod]
        public void Can_not_create_company_with_invalid_email()
        {
            var companyModel = _companyGenerator.Get();
            companyModel.Email = StringsGenerators.GenerateInvalidEmail();

            var response = _companyService.Create(companyModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.InvalidEmail));
        }

        [TestMethod]
        public void Can_not_create_company_with_invalid_country_code()
        {
            var companyModel = _companyGenerator.Get();
            companyModel.Country = StringsGenerators.GenerateInvalidCountryCode();

            var response = _companyService.Create(companyModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.InvalidCountryCode));
        }

        [TestMethod]
        public void Can_not_create_company_with_invalid_phone_number()
        {
            var companyModel = _companyGenerator.Get();
            companyModel.Phone = StringsGenerators.GenerateInvalidPhoneNumber(9);

            var response = _companyService.Create(companyModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.InvalidPhone));
        }

        [TestMethod]
        public void User_from_company_created_with_company_creation()
        {
            var company = CreateCompany();
            var userResponse = _userService.Get(c => c.CompanyId == company.Id).Data.FirstOrDefault();
            Assert.IsNotNull(userResponse.Data);
            Assert.AreEqual(company.Id, userResponse.Data.CompanyId);
        }

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();
		}
		#endregion
	}
}