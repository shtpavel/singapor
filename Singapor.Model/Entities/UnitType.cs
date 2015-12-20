using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class UnitType : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Field> Fields { get; set; } 
    }
}
