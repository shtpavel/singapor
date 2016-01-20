using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Models.Maps;
using Singapor.Services.Responses;
using Singapor.Tests.Generators;
using Singapor.Texts;

namespace Singapor.Tests
{
    public class UnitTestBase
    {
        #region Fields

        protected IGenerator<CompanyModel> _companyGenerator;
        protected ICompanyService _companyService;
        protected IContainer _container;
        protected IFieldModelGenerator _fieldGenerator;
        protected IFieldService _fieldService;
        protected IUnitModelGenerator _unitModelGenerator;
        protected IUnitService _unitService;
        protected IUnitTypeModelGenerator _unitTypeModelGenerator;
        protected IUnitTypeService _unitTypeService;
        protected IUnitScheduleModelGenerator _unitScheduleModelGenerator;
        protected IUnitScheduleService _unitScheduleService;

        #endregion

        #region Constructors

        public UnitTestBase()
        {
            _container = new TestsContainer().GetContainerBuilder();
            _container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());
        }

        #endregion

        #region Public methods

        public virtual void Setup()
        {
            _companyGenerator = _container.Resolve<IGenerator<CompanyModel>>();
            _companyService = _container.Resolve<ICompanyService>();
            _unitService = _container.Resolve<IUnitService>();
            _unitModelGenerator = _container.Resolve<IUnitModelGenerator>();
            _unitTypeModelGenerator = _container.Resolve<IUnitTypeModelGenerator>();
            _fieldGenerator = _container.Resolve<IFieldModelGenerator>();
            _unitTypeService = _container.Resolve<IUnitTypeService>();
            _fieldService = _container.Resolve<IFieldService>();
            _unitScheduleService = _container.Resolve<IUnitScheduleService>();
            _unitScheduleModelGenerator = _container.Resolve<IUnitScheduleModelGenerator>();
        }

        #endregion

        protected CompanyModel CreateCompany()
        {
            return _companyService.Create(_container.Resolve<IGenerator<CompanyModel>>().Get()).Data;
        }

        protected UnitTypeModel CreateUnitType(CompanyModel companyModel)
        {
            return
                _container.Resolve<IUnitTypeService>()
                    .Create(_container.Resolve<IUnitTypeModelGenerator>().Get(companyModel))
                    .Data;
        }

        protected UnitModel CreateUnit(CompanyModel companyModel, UnitTypeModel unitTypeModel)
        {
            return _container.Resolve<IUnitService>()
                .Create(_container.Resolve<IUnitModelGenerator>().Get(companyModel, unitTypeModel))
                .Data;
        }

        #region AssertionHelpers

        public void AssertValidationErrorIsInList(string errorMessage, ResponseBase response, string property = null)
        {
            Assert.IsFalse(response.IsValid);
            if (property != null)
                Assert.IsTrue(response.Errors.Any(x => x.Message.Equals(errorMessage) && x.Fields.Contains(property)));
            else
                Assert.IsTrue(response.Errors.Any(x => x.Message.Equals(errorMessage)));
            Assert.AreEqual(
                response.Errors.First(x => x.Message.Equals(errorMessage)).Type,
                ErrorType.Validation);
        }
        #endregion
    }
}