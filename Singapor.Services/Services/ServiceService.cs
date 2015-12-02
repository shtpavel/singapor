using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
	public class ServiceService : BaseService<ServiceModel, Service>, IServiceService
	{
		#region Constructors

		public ServiceService(IUnitOfWork unitOfWork, IRepository<Service> repository) : base(unitOfWork, repository)
		{
		}

		#endregion
	}
}