using System;
using Singapor.Services.Models;

namespace Singapor.Services.Abstract
{
	public class UnitModel : CompanyDependentModelBase
	{
		#region Properties

		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsContainer { get; set; }
		public Guid? TypeId { get; set; }
		public Guid? ParentUnitId { get; set; }

		#endregion
	}
}