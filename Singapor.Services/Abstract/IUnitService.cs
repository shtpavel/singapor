using System.Collections.Generic;
using Singapor.Services.Responses;

namespace Singapor.Services.Abstract
{
    public interface IUnitService : IService<UnitModel>
    {
        #region Public methods

        ListEntityResponse<UnitModel> Create(IEnumerable<UnitModel> units);

        #endregion
    }
}