using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Models.Validators.Unit
{
    public class NewUnitValidator : AbstractValidator<UnitModel>
    {
        public NewUnitValidator(
            ICompanyService companyService, 
            IUnitService unitService,
            IUnitTypeService unitTypeService)
        {
            RuleFor(x => x.CompanyId).NotNull().WithMessage(Validation.Required);
            RuleFor(x => x.CompanyId).Must(x =>
            {
                if (x.HasValue)
                {
                    var company = companyService.Get(x.Value);
                    return company != null;
                }
                return true;
            }).WithMessage(Validation.CompanyNotFound);
            
            RuleFor(x => x.ParentUnitId).Must(x =>
            {
                if (x.HasValue)
                {
                    var unit = unitService.Get(x.Value);
                    return unit != null;
                }
                return true;
            }).WithMessage(Validation.UnitNotFound);
            RuleFor(x => x.TypeId).NotNull().WithMessage(Validation.Required);
            RuleFor(x => x.TypeId).Must(x =>
            {
                if (x.HasValue)
                {
                    var type = unitTypeService.Get(x.Value);
                    return type != null;
                }
                return true;
            }).WithMessage(Validation.UnitTypeNotFound);

            RuleFor(x => x.Name).NotEmpty().WithMessage(Validation.Required);
        }
    }
}
