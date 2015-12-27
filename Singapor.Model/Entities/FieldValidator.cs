using System;

namespace Singapor.Model.Entities
{
    public class FieldValidator : EntityBase
    {
        #region Properties

        public string Value { get; set; }
        public string Description { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public ValidationType Type { get; set; }

        #endregion
    }

    public enum ValidationType
    {
        GreaterThen,
        GreaterOrEqualsThen,
        LessThen,
        LessOrEqualsThen,
        Contains,
        Equals,
        Regexp
    }
}