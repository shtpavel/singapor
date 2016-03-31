using Singapor.Services.Events;

namespace Singapor.Infrastructure.Listeners
{
	public abstract class ListenerBase<T> : IListener<T>
		where T : class
	{
		#region Public methods

		public abstract void Handle(T message);

		#endregion
	}
}