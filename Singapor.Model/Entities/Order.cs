using System;

namespace Singapor.Model.Entities
{
    public class Order : EntityBase
    {
        #region Properties

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public bool Verified { get; set; }
        public Guid UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        #endregion
    }
}