using TNTechnology.Business.Models.Admin;

namespace TNTechnology.Business.Services.Interfaces
{
    public interface IJwtUtilsService
    {
        string GenerateToken(AdminModel model);
        int? ValidateToken(string? token);
    }
}
