using System;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class UnitScheduleModel : ModelBase
    {
        #region Properties

        public DateTime? ExactDate { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }
        public int? BreakHour { get; set; }
        public int? BreakDuration { get; set; }
        public string Description { get; set; }
        public Guid? UnitId { get; set; }

        #endregion
    }
}