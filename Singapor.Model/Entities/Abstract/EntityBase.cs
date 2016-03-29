using System;

namespace Singapor.Model
{
	public class EntityBase
	{
		#region Properties

		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }

		#endregion

		#region Constructors

		public EntityBase()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
		}

		#endregion
	}
}