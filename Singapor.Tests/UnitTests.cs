using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.DAL.Repositories;
using Singapor.Services.Abstract;
using Unity;

namespace Singapor.Tests
{
    [TestClass]
    public class UnitTests
    {
        private IUnitService _unitService;

        [TestInitialize]
        public void Setup()
        {
            var container = new TestsContainer().CreateContainer();
            _unitService = container.Resolve<IUnitService>();
        }

        [TestMethod]
        public void Can_create_unit()
        {
            var model = new UnitModel()
            {
                Id = Guid.NewGuid(),
                Description = String.Empty,
                Name = "Test unit",
                IsParent = false,
            };

            _unitService.Create(model);

            var modelFromDb = _unitService.Get(model.Id);
        }
    }
}
