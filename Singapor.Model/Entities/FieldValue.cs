using System;

namespace Singapor.Model.Entities
{
    public class FieldValue : EntityBase
    {
        #region Properties

        public string Value { get; set; }
        public Guid FieldId { get; set; }
        public Guid UnitIt { get; set; }
        public Unit Unit { get; set; }
        public Field Field { get; set; }

        #endregion
    }
}