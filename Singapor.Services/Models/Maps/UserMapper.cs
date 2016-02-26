using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
    public class UserMapper : IMapConfiguration
    {
        public void Map()
        {
            Mapper.CreateMap<UserModel, User>();
            Mapper.CreateMap<User, UserModel>();

            Mapper.CreateMap<RoleModel, Role>();
            Mapper.CreateMap<Role, RoleModel>();
        }
    }
}
