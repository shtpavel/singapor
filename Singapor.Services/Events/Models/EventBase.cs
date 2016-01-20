using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;

namespace Singapor.Services.Events
{
    public class EventBase
    {
        public DateTime DateCreated { get; private set; }

        public EventBase()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
