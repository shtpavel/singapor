using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
    public interface IUnitScheduleModelGenerator
    {
        UnitScheduleModel Get(UnitModel unitModel, DayOfWeek dayOfWeek, DateTime? exactDate);
    }
}
