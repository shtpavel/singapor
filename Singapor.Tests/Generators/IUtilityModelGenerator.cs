using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
    public interface IUtilityModelGenerator : IGenerator<UtilityModel>
    {
        #region Public methods

        UtilityModel Get(CompanyModel utilityModel);

        #endregion
    }
}
