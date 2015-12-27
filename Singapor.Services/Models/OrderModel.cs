using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class OrderModel : ModelBase
    {
        #region Properties

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }
        public Guid UnitId { get; set; }

        #endregion
    }
}