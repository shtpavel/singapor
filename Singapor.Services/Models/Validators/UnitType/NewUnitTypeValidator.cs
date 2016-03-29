using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models.Validators.UnitType
{
	internal class NewUnitTypeValidator : AbstractValidator<UnitTypeModel>
	{
		public NewUnitTypeValidator(
			ICompanyService companyService,
			IUnitTypeService unitTypeService)
		{
		}
	}
}
