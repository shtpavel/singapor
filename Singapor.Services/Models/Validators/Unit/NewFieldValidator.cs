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
    public class NewFieldValidator : AbstractValidator<FieldModel>
    {

        public NewFieldValidator(IRepository<UnitType> unitTypeRepository)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
            RuleFor(x => x.Name).Length(5, 20).WithMessage(Validation.LengthBetween, 5, 20);
            RuleFor(x => x.UnitTypeId).NotNull().WithMessage(Validation.Required);
            RuleFor(x => x.UnitTypeId).Must(x =>
            {
                if (x.HasValue)
                {
                    return unitTypeRepository.GetById(x.Value) != null;
                }

                return false;
            }).WithMessage(Validation.Required);

        }

    }
}
