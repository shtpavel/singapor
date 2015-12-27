using System;
using System.Collections.Generic;

namespace Singapor.Model.Entities
{
    public class Field : EntityBase
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public Guid UnitTypeId { get; set; }
        public UnitType UnitType { get; set; }
        public FieldType Type { get; set; }
        public virtual ICollection<FieldValidator> Validators { get; set; }

        #endregion
    }

    public enum FieldType
    {
        String,
        Integer,
        Float,
        Decimal
    }
}