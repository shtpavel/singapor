using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
	public class UserMapper : IMapConfiguration
	{
		#region Public methods

		public void Map()
		{
			Mapper.CreateMap<UserModel, User>();
			Mapper.CreateMap<User, UserModel>();

			Mapper.CreateMap<RoleModel, Role>();
			Mapper.CreateMap<Role, RoleModel>();
		}

		#endregion
	}
}