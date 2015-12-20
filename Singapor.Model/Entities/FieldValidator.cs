using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class FieldValidator : EntityBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public ValidationType Type { get; set; }
    }

    public enum ValidationType
    {
        GreateThen,
        GreaterOrEqualThen,
        LessThen,
        LessOrEqualThen,
        Contains,
        Equals,
        Regexp
    }
}
