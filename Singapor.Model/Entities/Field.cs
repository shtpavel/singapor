using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class Field : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public Guid UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }
        public FieldType Type { get; set; }
        public virtual ICollection<FieldValidator> Validators { get; set; } 
    }

    public enum FieldType
    {
        String,
        Integer,
        Float,
        Decimal,
    }
}
