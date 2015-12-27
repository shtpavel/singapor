using System;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class FieldValidatorModel : ModelBase
    {
        #region Properties

        public string Value { get; set; }
        public string Description { get; set; }
        public Guid? FieldId { get; set; }
        public ValidationType Type { get; set; }

        #endregion
    }
}