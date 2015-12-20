using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Responses;

namespace Singapor.Services.Abstract
{
    public interface IUnitService : IService<UnitModel>
    {
        ListResponse<UnitModel> Create(IEnumerable<UnitModel> units);
    }
}
