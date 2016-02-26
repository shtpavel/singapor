using System;
using System.Collections.Generic;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class UnitTypeModel : ModelBase
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsContainer { get; set; }
        public Guid? CompanyId { get; set; }

        #endregion

        #region Constructors

        public UnitTypeModel()
        {
        }

        #endregion
    }
}