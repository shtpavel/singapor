using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
    public interface IUnitModelGenerator : IGenerator<UnitModel>
    {
        #region Public methods

        UnitModel Get(CompanyModel companyModel);
        UnitModel Get(CompanyModel companyModel, UnitTypeModel unitTypeModel);

        #endregion
    }
}