using TNTechnology.Business.Models.Roles;

namespace TNTechnology.Business.Authorization
{
    public class ApplicationAdmin
    {
        public long Id { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public string? Avatar { get; set; }

        public int TimeZone { get; set; }

        public List<RolesModel> Roles { get; set; }

        public ApplicationAdmin()
        {
            Roles = new List<RolesModel>();
        }
    }
}
