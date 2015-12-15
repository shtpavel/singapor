using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;
using Singapor.Texts;
using Unity;

namespace Singapor.Tests
{
    [TestClass]
    public class CompanyTests
    {
        private ICompanyService _companyService;

        [TestInitialize]
        public void Setup()
        {
            var container = new TestsContainer().CreateContainer();
            _companyService = container.Resolve<ICompanyService>();
        }

        [TestMethod]
        public void Can_create_company()
        {
            var companyModel = new CompanyModel()
            {
                Name = "Name of company",
                Description = "Descr"
            };

            var response = _companyService.Create(companyModel);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_not_create_company_with_empty_name()
        {
            var companyModel = new CompanyModel()
            {
                Name = "",
                Description = "Descr"
            };

            var response = _companyService.Create(companyModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.Required));
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Type, ErrorType.Validation);
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.Required)).Fields.Count(), 1);
        }

        [TestMethod]
        public void Can_not_create_company_with_invalid_name_length()
        {
            var companyModel = new CompanyModel()
            {
                Name = "Name",
                Description = "Descr"
            };

            var response = _companyService.Create(companyModel);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == string.Format(Validation.LengthBetween, 6, 20)));
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(string.Format(Validation.LengthBetween, 6, 20))).Type, ErrorType.Validation);
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(string.Format(Validation.LengthBetween, 6, 20))).Fields.Count(), 1);
        }

        [TestMethod]
        public void Can_not_create_company_with_duplicate_id()
        {
            var companyModel = new CompanyModel()
            {
                Name = "Name1212",
                Description = "Descr"
            };
            var response = _companyService.Create(companyModel);
            response = _companyService.Create(response.Data);

            Assert.IsFalse(response.IsValid);
            Assert.IsTrue(response.Errors.Any(x => x.Message == Validation.UniqueId));
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.UniqueId)).Type, ErrorType.Validation);
            Assert.AreEqual(response.Errors.First(x => x.Message.Equals(Validation.UniqueId)).Fields.Count(), 1);
        }
    }
}
