using TNTechnology.Business.Models.Admin;

namespace TNTechnology.Business.Services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminModel?> Get(long id);
    }
}
