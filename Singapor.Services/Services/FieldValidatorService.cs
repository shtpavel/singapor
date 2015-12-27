using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class FieldValidatorService : BaseService<FieldValidatorModel, FieldValidator>, IFieldValidatorService
    {
        #region Constructors

        public FieldValidatorService(
            IUnitOfWork unitOfWork,
            IRepository<FieldValidator> repository) : base(unitOfWork, repository)
        {
        }

        #endregion
    }
}