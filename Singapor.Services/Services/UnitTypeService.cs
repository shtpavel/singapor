using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
	public class UnitTypeService : BaseService<UnitTypeModel, UnitType>, IUnitTypeService
	{
		#region Constructors

		public UnitTypeService(IUnitOfWork unitOfWork, IRepository<UnitType> repository) : base(unitOfWork, repository)
		{
		}

		#endregion

		public override SingleEntityResponse<UnitTypeModel> Create(UnitTypeModel model)
		{

			return base.Create(model);
		}
	}
}