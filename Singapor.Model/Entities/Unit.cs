using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class Unit : BaseEntity
    {
        public UnitType Type { get; set; }
        public Guid TypeId { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public bool IsContainer { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
        public virtual Company Company { get; set; }
    }
}
