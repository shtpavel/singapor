using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class UnitScheduleModel : ModelBase
    {
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
    }
}
