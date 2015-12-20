using System;

namespace Singapor.Services.Abstract
{
    public class UnitModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsContainer { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? ParentUnitId { get; set; }
    }
}