using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singapor.Tests.Tests
{
	[TestClass]
	public class EndToEndTests : UnitTestBase
	{
		#region Public methods

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();
		}

		[TestMethod]
		public void Simple_end_to_end_test()
		{
			var companyModel = CreateCompany();
			var unitTypeModel = CreateUnitType(companyModel);
			var unitModel = CreateUnit(companyModel, unitTypeModel);

			Assert.IsTrue(_unitService.Get().Data.Any());
		}

		#endregion
	}
}