using System;

namespace Singapor.Model.Entities.Abstract
{
    public class CompanyDependentEntityBase : EntityBase
    {
        #region Properties

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        #endregion
    }
}