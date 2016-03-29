using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
	public class UnitTypeModel : CompanyDependentModelBase
	{
		#region Properties

		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsContainer { get; set; }

		#endregion
	}
}