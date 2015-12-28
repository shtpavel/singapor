using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Texts;

namespace Singapor.Tests.Tests
{
    [TestClass]
    public class UnitScheduleTests : UnitTestBase
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestMethod]
        public void Can_create_unit_schedule()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);
            var unitModel = CreateUnit(companyModel, unitTypeModel);

            var unitScheduleModel = _unitScheduleModelGenerator.Get(unitModel, DayOfWeek.Monday, null);

            var response = _unitScheduleService.Create(unitScheduleModel);

            Assert.IsTrue(response.IsValid);
        }

        [TestMethod]
        public void Can_not_create_unit_schedule_for_the_same_day_of_the_week()
        {
            var companyModel = CreateCompany();
            var unitTypeModel = CreateUnitType(companyModel);
            var unitModel = CreateUnit(companyModel, unitTypeModel);
            
            var unitScheduleModelOne = _unitScheduleModelGenerator.Get(unitModel, DayOfWeek.Monday, null);
            var unitScheduleModelTwo = _unitScheduleModelGenerator.Get(unitModel, DayOfWeek.Monday, null);

            var responseOne = _unitScheduleService.Create(unitScheduleModelOne);
            Assert.IsTrue(responseOne.IsValid);

            var responseTwo = _unitScheduleService.Create(unitScheduleModelTwo);
            AssertValidationErrorIsInList(Validation.DuplicateScheduleForDate, responseTwo, "DayOfWeek");
        }
    }
}
