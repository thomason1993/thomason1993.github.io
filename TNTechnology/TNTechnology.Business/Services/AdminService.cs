using TNTechnology.Business.Models.Admin;
using TNTechnology.Business.Services.Interfaces;

namespace TNTechnology.Business.Services
{
    public class AdminService : IAdminService
    {
        public Task<AdminModel?> Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
