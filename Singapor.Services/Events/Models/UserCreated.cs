using Singapor.Services.Models;

namespace Singapor.Services.Events
{
	public class UserCreated : EventBase
	{
		#region Properties

		public UserModel Data { get; private set; }

		#endregion

		#region Constructors

		public UserCreated(UserModel data)
		{
			Data = data;
		}

		#endregion
	}
}