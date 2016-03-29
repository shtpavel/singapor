using System.Collections.Generic;

namespace Singapor.Model.Entities
{
	public class Company : EntityBase
	{
		#region Properties

		public string Name { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public virtual ICollection<Unit> Units { get; set; }
		public virtual ICollection<UnitType> UnitTypes { get; set; }

		#endregion
	}
}