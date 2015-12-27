using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Unit;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
    public class FieldService : BaseService<FieldModel, Field>, IFieldService
    {
        private readonly IRepository<UnitType> _unitTypeRepository;

        #region Constructors

        public FieldService(
            IUnitOfWork unitOfWork,
            IRepository<Field> fieldRepository,
            IRepository<UnitType> unitTypeRepository)
            : base(unitOfWork, fieldRepository)
        {
            _unitTypeRepository = unitTypeRepository;
        }

        public override SingleEntityResponse<FieldModel> Create(FieldModel model)
        {
            var validator = new NewFieldValidator(_unitTypeRepository);
            var response = validator.Validate(model);
            if (!response.IsValid)
                return new SingleEntityResponse<FieldModel>(model, response.GetErrorsObjects().ToList());

            return base.Create(model);
        }

        #endregion
    }
}