using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Responses;
using Singapor.Texts;

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

		[TestMethod, Ignore]
		public void Can_not_create_company_with_duplicate_id()
		{
			var companyModel = _companyGenerator.Get();
			var response = _companyService.Create(companyModel);
			response = _companyService.Create(response.Data);

			Assert.IsFalse(response.IsValid);
			Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.UniqueId));
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.UniqueId)).Type, ErrorType.Validation);
			Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.UniqueId)).Fields.Count(), 1);
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
			companyModel.Name = "123";

			var response = _companyService.Create(companyModel);

			AssertValidationErrorIsInList(string.Format(Validation.LengthBetween, 6, 20), response);
		}

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();
		}

		#endregion
	}
}