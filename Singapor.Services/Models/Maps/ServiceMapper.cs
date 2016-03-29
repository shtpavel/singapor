using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
	public class ServiceMapper : IMapConfiguration
	{
		#region Public methods

		public void Map()
		{
			Mapper.CreateMap<ServiceModel, Service>();
			Mapper.CreateMap<Service, ServiceModel>();
		}

		#endregion
	}
}