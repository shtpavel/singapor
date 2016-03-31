using System.Collections.Generic;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
	public class Role : EntityBase
	{
		#region Properties

		public string Name { get; set; }

		public virtual ICollection<User> Users { get; set; }

		#endregion
	}
}