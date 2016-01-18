using Singapor.Services.Models;

namespace Singapor.Services.Abstract
{
    public interface IUserService : IService<UserModel>
    {
        UserModel Get(string email, string password);
    }
}