using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.SqlServer.Server;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Auth;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
    public class UserService : BaseService<UserModel, User>, IUserService
    {
        public UserService(
            IUnitOfWork unitOfWork, 
            IRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public override SingleEntityResponse<UserModel> Create(UserModel model)
        {
            model.Password = PasswordHasher.Hash(model.Password);
            return base.Create(model);
        }

        public UserModel Get(string email, string password)
        {
            var user = 
                this._repository
                    .GetAll()
                    .SingleOrDefault(x => x.Email == email && 
                        PasswordHasher.Verify(password, x.Password));

            if (user == null)
                return null;

            return Mapper.Map(user, new UserModel());
        }
    }
}
