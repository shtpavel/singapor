using System.Collections.Generic;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
	public class User : CompanyDependentEntityBase
	{
		#region Properties

		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public virtual ICollection<Role> Roles { get; set; }

		#endregion
	}
}