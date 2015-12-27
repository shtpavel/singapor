using System;
using System.Collections.Generic;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class FieldModel : ModelBase
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? UnitTypeId { get; set; }
        public FieldType Type { get; set; }
        public ICollection<FieldValidatorModel> Validators { get; set; }

        #endregion

        #region Constructors

        public FieldModel()
        {
            Validators = new List<FieldValidatorModel>();
        }

        #endregion
    }
}