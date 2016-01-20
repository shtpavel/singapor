using Autofac;
using Singapor.Infrastructure.EventAggregator.Listeners;
using Singapor.Services.Events;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
    public class EventSystemModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventAggregatorProvider>().As<IEventAggregatorProvider>().SingleInstance();
            builder.RegisterType<UserCreatedListener>().As<IListener<UserCreated>>();
        }
    }
}
