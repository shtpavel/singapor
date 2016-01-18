using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
    public class CompanyMapper : IMapConfiguration
    {
        #region Public methods

        public void Map()
        {
            Mapper.CreateMap<CompanyModel, Company>();
            Mapper.CreateMap<Company, CompanyModel>();
        }

        #endregion
    }
}