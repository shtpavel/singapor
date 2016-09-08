using AutoMapper;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models.Maps
{
	public class UnitMapper : IMapConfiguration
	{
		#region Public methods

		public void Map()
		{
			Mapper.CreateMap<UnitModel, Unit>()
				.ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
				.ForMember(dst => dst.Name, src => src.MapFrom(x => x.Name))
				.ForMember(dst => dst.CompanyId, src => src.MapFrom(x => x.CompanyId))
				.ForMember(dst => dst.Description, src => src.MapFrom(x => x.Description))
				.ForMember(dst => dst.IsContainer, src => src.MapFrom(x => x.IsContainer))
				.ForMember(dst => dst.TypeId, src => src.MapFrom(x => x.TypeId));

			Mapper.CreateMap<Unit, UnitModel>();


			Mapper.CreateMap<UnitTypeModel, UnitType>();
			Mapper.CreateMap<UnitType, UnitTypeModel>();
		}

		#endregion
	}
}