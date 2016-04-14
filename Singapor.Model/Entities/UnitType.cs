using Singapor.Common.Enums;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
	public class UnitType : CompanyDependentEntityBase
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