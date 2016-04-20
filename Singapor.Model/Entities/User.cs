using System;
using System.Collections.Generic;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
	public class User : EntityBase
	{
		#region Properties

		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public virtual ICollection<Role> Roles { get; set; }
		public Guid CompanyId { get; set; }
		public virtual Company Company { get; set; }

		public User()
		{
			Roles = new List<Role>();
		}

		#endregion
	}
}