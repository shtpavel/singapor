using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Services
{
    public class UnitService : BaseService<UnitModel, Unit>, IUnitService
    {
        public UnitService(IUnitOfWork unitOfWork, IRepository<Unit> repository) : base(unitOfWork, repository)
        {
        }
    }
}
