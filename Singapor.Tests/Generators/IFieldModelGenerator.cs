using System.Collections.Generic;
using Singapor.Model.Entities;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
    public interface IFieldModelGenerator : IGenerator<FieldModel>
    {
        #region Public methods

        FieldModel Get(UnitTypeModel unitTypeModel, FieldType type);

        FieldModel Get(UnitTypeModel unitTypeModel, FieldType type,
            ICollection<FieldValidatorModel> fieldValidatorModels);

        #endregion
    }
}