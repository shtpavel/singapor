using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Tests.Generators;
using Singapor.Texts;
using Unity;

namespace Singapor.Tests
{
    [TestClass]
    public class UnitTests
    {
        #region Fields

        private ICompanyService _companyService;
        private IUnityContainer _container;
        private IGenerator<UnitModel> _unitModelGenerator;
        private IUnitService _unitService;

        #endregion

        #region Public methods

        [TestInitialize]
        public void Setup()
        {
            _container = new TestsContainer().CreateContainer();
            _companyService = _container.Resolve<ICompanyService>();
            _unitService = _container.Resolve<IUnitService>();
            _unitModelGenerator = _container.Resolve<IGenerator<UnitModel>>();
        }

        [TestMethod]
        public void CanCreateUnit()
        {
            CreateCompany();
            CreateUnitType();

            var model = _unitModelGenerator.Get();

            var response = _unitService.Create(model);

            Assert.IsTrue(response.IsValid);
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

        #endregion

        #region Private methods

        private void CreateCompany()
        {
            _companyService.Create(_container.Resolve<IGenerator<CompanyModel>>().Get());
        }

        private void CreateUnitType()
        {
            _container.Resolve<IUnitTypeService>().Create(_container.Resolve<IGenerator<UnitTypeModel>>().Get());
        }

        #endregion
    }
}