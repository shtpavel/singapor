using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
    public class CompanyMapper : IMapConfiguration
    {
        #region Public methods

        public void Map()
        {
            Mapper.CreateMap<CompanyModel, Company>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dst => dst.Phone, src => src.MapFrom(x => x.Phone))
                .ForMember(dst => dst.Description, src => src.MapFrom(x => x.Description))
                .ForMember(dst => dst.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dst => dst.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dst => dst.Address, src => src.MapFrom(x => x.Address));

            Mapper.CreateMap<Company, CompanyModel>();
        }

        #endregion
    }
}