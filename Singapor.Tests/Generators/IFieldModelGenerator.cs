using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
    public interface IFieldModelGenerator : IGenerator<FieldModel>
    {
        FieldModel Get(UnitTypeModel unitTypeModel, FieldType type);
        FieldModel Get(UnitTypeModel unitTypeModel, FieldType type, ICollection<FieldValidatorModel> fieldValidatorModels);
    }
}
