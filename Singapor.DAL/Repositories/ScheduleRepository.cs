using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class ScheduleRepository : BaseRepository<UnitSchedule>
    {
        public ScheduleRepository(IDataContext context)
            : base(context)
        {
            
        }
    }
}
