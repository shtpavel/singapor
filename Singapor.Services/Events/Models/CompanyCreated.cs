using Singapor.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Events.Models
{
    public class CompanyCreated : EventBase
    {
        #region Properties

        public CompanyModel Data { get; private set; }

        #endregion

        #region Constructors

        public CompanyCreated(CompanyModel data)
        {
            Data = data;
        }

        #endregion
    }
}
