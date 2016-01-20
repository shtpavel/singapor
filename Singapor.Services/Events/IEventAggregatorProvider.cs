namespace Singapor.Services.Events
{
    public interface IEventAggregatorProvider
    {
        IEventAggregator GetEventAggregator();
    }
}