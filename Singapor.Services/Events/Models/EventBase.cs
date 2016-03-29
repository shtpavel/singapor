using System;

namespace Singapor.Services.Events
{
	public class EventBase
	{
		#region Properties

		public DateTime DateCreated { get; private set; }

		#endregion

		#region Constructors

		public EventBase()
		{
			DateCreated = DateTime.UtcNow;
		}

		#endregion
	}
}