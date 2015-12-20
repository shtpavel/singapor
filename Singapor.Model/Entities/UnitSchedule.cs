using System;

namespace Singapor.Model.Entities
{
    public class UnitSchedule : EntityBase
    {
        #region Properties

        public ScheduleType Type { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime ExactDate { get; set; }
        public int OpenHour { get; set; }
        public int CloseHour { get; set; }
        public int BreakHour { get; set; }
        public int BreakDuration { get; set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public string Description { get; set; }

        #endregion
    }
}