using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class FieldValueService : BaseService<FieldValueModel, FieldValue>, IFieldValueService
    {
        #region Constructors

        public FieldValueService(
            IUnitOfWork unitOfWork,
            IRepository<FieldValue> repository) : base(unitOfWork, repository)
        {
        }

        #endregion
    }
}