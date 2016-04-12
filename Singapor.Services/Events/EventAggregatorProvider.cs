using System.Threading.Tasks;
using Autofac;
using Singapor.Services.Events.Models;

namespace Singapor.Services.Events
{
	public class EventAggregatorProvider : IEventAggregatorProvider
	{
		#region Fields

		private readonly IContainer _container;
		private readonly IEventAggregator _eventAggregator;

		#endregion

		#region Constructors

		public EventAggregatorProvider(IContainer container)
		{
			var config = new EventAggregator.Config
			{
				//DefaultThreadMarshaler = action => Task.Factory.StartNew(action)
			};

			_eventAggregator = new EventAggregator(config);
			_container = container;
		}

		#endregion

		#region Public methods

		public IEventAggregator GetEventAggregator()
		{
			return _eventAggregator;
		}

		#endregion

		#region Private methods

		private void RegisterAllKnownListeners()
		{
			_eventAggregator.AddListener(_container.Resolve<IListener<UserCreated>>());
            _eventAggregator.AddListener(_container.Resolve<IListener<CompanyCreated>>());

        }

		#endregion
	}
}