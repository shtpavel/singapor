﻿using System;
using System.Collections.Generic;

namespace Singapor.Model.Entities
{
    public class Unit : EntityBase
    {
        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsContainer { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public Guid? TypeId { get; set; }
        public UnitType Type { get; set; }
        public Guid? ParentUnitId { get; set; }
        public Unit ParentUnit { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        #endregion
    }
}