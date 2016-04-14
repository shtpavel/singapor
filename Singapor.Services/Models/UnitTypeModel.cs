using Singapor.Common.Enums;

namespace Singapor.Services.Models
{
	public class UnitTypeModel : CompanyDependentModelBase
	{
		#region Properties

		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsContainer { get; set; }
		public bool IsUtilityProvider { get; set; }
		public TimeIntervalUnit TimeIntervalUnit { get; set; }

		#endregion
	}
}