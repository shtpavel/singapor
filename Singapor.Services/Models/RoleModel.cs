using System;
using System.Collections.Generic;

namespace Singapor.Services.Models
{
	public class RoleModel
	{
		#region Properties

		public Guid? Id { get; set; }
		public string Name { get; set; }
		public ICollection<UserModel> Users { get; set; }

		#endregion
	}
}