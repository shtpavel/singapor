using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
	public class UtilityService : BaseService<UtilityModel, Utility>, IUtilityService
	{
		#region Constructors

		public UtilityService(IUnitOfWork unitOfWork, IRepository<Utility> repository) : base(unitOfWork, repository)
		{
		}

		#endregion
	}
}