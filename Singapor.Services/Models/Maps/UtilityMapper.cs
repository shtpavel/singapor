using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
	public class UtilityMapper : IMapConfiguration
	{
		#region Public methods

		public void Map()
		{
			Mapper.CreateMap<UtilityModel, Utility>();
			Mapper.CreateMap<Utility, UtilityModel>();
		}

		#endregion
	}
}