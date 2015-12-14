﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Unity;

namespace Singapor.Tests
{
    [TestClass]
    public class UnitTests
    {
        #region Fields

        private IUnitService _unitService;

        #endregion

        #region Public methods

        [TestMethod]
        public void Can_create_unit()
        {
            var model = new UnitModel
            {
                Id = Guid.NewGuid(),
                Description = string.Empty,
                Name = "Test unit",
                IsParent = false
            };

            _unitService.Create(model);

            Assert.IsTrue(_unitService.Get().Any());
        }

        [TestMethod]
        public void Can_remove_unit()
        {
            var model = new UnitModel
            {
                Id = Guid.NewGuid(),
                Description = string.Empty,
                Name = "Test unit",
                IsParent = false
            };

            _unitService.Create(model);

            Assert.IsTrue(_unitService.Get().Any());

            _unitService.Delete(model.Id);

            Assert.IsFalse(_unitService.Get().Any());
        }

        [TestMethod]
        public void Can_update_unit()
        {
            var model = new UnitModel
            {
                Id = Guid.NewGuid(),
                Description = string.Empty,
                Name = "Test unit",
                IsParent = false
            };

            _unitService.Create(model);

            Assert.IsTrue(_unitService.Get().Any());

            var oldModel = _unitService.Get(model.Id);

            Assert.IsNotNull(oldModel);

            oldModel.Name = "Updated";

            _unitService.Update(oldModel);

            var updatedModel = _unitService.Get(model.Id);

            Assert.AreEqual(updatedModel.Name, "Updated");
        }

        [TestInitialize]
        public void Setup()
        {
            var container = new TestsContainer().CreateContainer();
            _unitService = container.Resolve<IUnitService>();
        }

        #endregion
    }
}