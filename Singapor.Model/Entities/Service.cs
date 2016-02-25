using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
    public class Service : CompanyDependentEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
