using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Singapor.Services.Abstract;

namespace Singapor.Services.Events
{
    public class EventAggregatorProvider : IEventAggregatorProvider
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IContainer _container;

        public EventAggregatorProvider(IContainer container)
        {
            var config = new EventAggregator.Config
            {
                DefaultThreadMarshaler = action => Task.Factory.StartNew(action)
            };

            _eventAggregator = new EventAggregator(config);
            _container = container;

            RegisterAllKnownListeners();
        }

        private void RegisterAllKnownListeners()
        {
            _eventAggregator.AddListener(_container.Resolve<IListener<UserCreated>>());
        }

        public IEventAggregator GetEventAggregator()
        {
            return _eventAggregator;
        }
    }
}
