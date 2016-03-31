﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singapor.Tests.Tests
{
	[TestClass]
	public class UnitTypeTests : UnitTestBase
	{
		#region Public methods

		[TestMethod, Ignore]
		public void Can_create_unit_type_without_fields()
		{
			var companyModel = _companyGenerator.Get();
			var unitTypeModel = _unitTypeModelGenerator.Get(companyModel);

			var response = _unitTypeService.Create(unitTypeModel);

			Assert.IsTrue(response.IsValid);
		}

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();
		}

		#endregion
	}
}