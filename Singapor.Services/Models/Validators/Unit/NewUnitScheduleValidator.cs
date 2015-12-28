using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Unit
{
    public class NewUnitScheduleValidator : AbstractValidator<UnitScheduleModel>
    {
        public NewUnitScheduleValidator(
            IRepository<UnitSchedule> unitScheduleRepository,
            IRepository<Model.Entities.Unit> unitRepository)
        {

            RuleFor(x => x.UnitId)
                .NotNull()
                .Must(x => unitRepository.GetById(x.Value) != null)
                .WithMessage(Validation.Required);

            RuleFor(x => x)
                .Must(x =>
                {
                    if (x.ExactDate == null)
                    {
                        return !unitScheduleRepository
                            .GetAll()
                            .Any(y => y.ExactDate == null && y.DayOfWeek == x.DayOfWeek && y.UnitId == x.UnitId);
                    }
                    else
                    {
                        return unitScheduleRepository
                            .GetAll()
                            .All(y => y.ExactDate != x.ExactDate && y.UnitId == x.UnitId);
                    }
                })
                .WithName("DayOfWeek")
                .WithMessage(Validation.DuplicateScheduleForDate);
        }
    }
}
