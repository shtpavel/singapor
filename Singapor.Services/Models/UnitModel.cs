using System;

namespace Singapor.Services.Abstract
{
    public class UnitModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsParent { get; set; }
        public Guid UnitTypeId { get; set; }
    }
}