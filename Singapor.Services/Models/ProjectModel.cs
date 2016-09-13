using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Models
{
    public class ProjectModel : CompanyDependentModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
