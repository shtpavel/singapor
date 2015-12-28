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
    public class UnitScheduleService : BaseService<UnitScheduleModel, UnitSchedule>, IUnitScheduleService
    {
        private readonly UnitRepository _unitRepository;

        #region Constructors

        public UnitScheduleService(
            IUnitOfWork unitOfWork, 
            IRepository<UnitSchedule> repository,
            UnitRepository unitRepository)
            : base(unitOfWork, repository)
        {
            _unitRepository = unitRepository;
        }


        public override SingleEntityResponse<UnitScheduleModel> Create(UnitScheduleModel model)
        {
            var newUnitScheduleValidator = new NewUnitScheduleValidator(_repository, _unitRepository);
            var validationReponse = newUnitScheduleValidator.Validate(model);
            if (!validationReponse.IsValid)
                return new SingleEntityResponse<UnitScheduleModel>(model, validationReponse.GetErrorsObjects().ToList());

            return base.Create(model);
        }

        #endregion
    }
}