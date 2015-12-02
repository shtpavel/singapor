using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class Company : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
