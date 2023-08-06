using TNTechnology.Business.Models.User;
using TNTechnology.Business.Services.Interfaces;

namespace TNTechnology.Business.Services
{
    public class UserService : IUserService
    {
        public Task<UserModel?> Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
