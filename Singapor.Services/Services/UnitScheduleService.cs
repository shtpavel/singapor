using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class UnitScheduleService : BaseService<UnitScheduleModel, UnitSchedule>, IUnitScheduleService
    {
        #region Constructors

        public UnitScheduleService(IUnitOfWork unitOfWork, IRepository<UnitSchedule> repository)
            : base(unitOfWork, repository)
        {
        }

        #endregion
    }
}