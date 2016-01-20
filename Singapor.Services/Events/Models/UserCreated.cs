using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Models;

namespace Singapor.Services.Events
{
    public class UserCreated : EventBase
    {
        public UserModel Data { get; private set; }

        public UserCreated(UserModel data)
        {
            Data = data;
        }
    }
}
