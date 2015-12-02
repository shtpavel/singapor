namespace Singapor.Services.Events
{
	public interface IEventAggregatorProvider
	{
		#region Public methods

		IEventAggregator GetEventAggregator();

		#endregion
	}
}