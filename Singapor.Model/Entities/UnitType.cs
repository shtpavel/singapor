using System;
using System.Collections.Generic;

namespace Singapor.Model.Entities
{
    public class UnitType : EntityBase
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsContainer { get; set; }
        public bool IsServicable { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Field> Fields { get; set; }

        #endregion
    }
}