using TNTechnology.Business.Models.User;

namespace TNTechnology.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> Get(long id);
    }
}
