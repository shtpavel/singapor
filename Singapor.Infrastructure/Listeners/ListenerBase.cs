using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;
using Singapor.Services.Events;

namespace Singapor.Infrastructure.EventAggregator.Listeners
{
    public abstract class ListenerBase<T> : IListener<T>
        where T : class
    {
        public abstract void Handle(T message);
    }
}
