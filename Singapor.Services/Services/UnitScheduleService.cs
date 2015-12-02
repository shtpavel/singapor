using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class UnitScheduleService : BaseService<UnitScheduleModel, UnitSchedule>, IUnitScheduleService
    {
        public UnitScheduleService(IRepository<UnitSchedule> repository) : base(repository)
        {
        }
    }
}
