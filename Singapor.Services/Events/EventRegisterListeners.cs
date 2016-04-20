using Autofac;
using Singapor.Services.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Events
{
    public class EventRegisterListeners : IEventRegisterListeners
    {
        private readonly IContainer _container;
        private readonly IEventAggregatorProvider _eventAggregatorProvider;

        public EventRegisterListeners(IContainer container, IEventAggregatorProvider eventAggregatorProvider)
        {
            _container = container;
            _eventAggregatorProvider = eventAggregatorProvider;
        }

        public void RegisterListeners()
        {
	        var userCreateListener = _container.Resolve<IListener<UserCreated>>();
	        _eventAggregatorProvider.GetEventAggregator().AddListener(userCreateListener,true);
	        var companyCreatedListener = _container.Resolve<IListener<CompanyCreated>>();
	        _eventAggregatorProvider.GetEventAggregator().AddListener(companyCreatedListener,true);
        }
    }
}
