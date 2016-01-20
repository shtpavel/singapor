using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Helpers;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators.Unit
{
    public class UnitScheduleModelGenerator : IUnitScheduleModelGenerator
    {
        public UnitScheduleModel Get(UnitModel unitModel, DayOfWeek dayOfWeek, DateTime? exactDate)
        {
            return new UnitScheduleModel()
            {
                DayOfWeek = dayOfWeek,
                OpenHour = 0,
                CloseHour = 0,
                BreakHour = 13,
                BreakDuration = 1,
                Description = StringsGenerators.GenerateString(199),
                ExactDate = exactDate,
                UnitId = unitModel.Id
            };
        }
    }
}
