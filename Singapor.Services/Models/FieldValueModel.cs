using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class FieldValueModel : ModelBase
    {
        #region Properties

        public string Value { get; set; }
        public Guid FieldId { get; set; }

        #endregion
    }
}