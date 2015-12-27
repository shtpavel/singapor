using System.Collections.Generic;
using Singapor.Model.Entities;
using Singapor.Services.Models;
using Singapor.Tests.Generators.Helpers;

namespace Singapor.Tests.Generators.Unit
{
    public class FieldModelGenerator : IFieldModelGenerator
    {
        #region Public methods

        public FieldModel Get()
        {
            var model = new FieldModel();

            model.Name = StringsGenerators.GenerateString(10);
            model.Description = StringsGenerators.GenerateString(199);

            return model;
        }

        public FieldModel Get(UnitTypeModel unitTypeModel)
        {
            var model = Get();
            model.UnitTypeId = unitTypeModel.Id;
            return model;
        }

        public FieldModel Get(UnitTypeModel unitTypeModel, FieldType type)
        {
            var model = Get(unitTypeModel);
            model.Type = type;

            return model;
        }

        public FieldModel Get(UnitTypeModel unitTypeModel, FieldType type,
            ICollection<FieldValidatorModel> fieldValidatorModels)
        {
            var model = Get(unitTypeModel, type);
            model.Validators = fieldValidatorModels;

            return model;
        }

        #endregion
    }
}