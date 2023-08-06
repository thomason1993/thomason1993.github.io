using TNTechnology.Business.Core;
using TNTechnology.Business.Models.Base;
using TNTechnology.Business.Models.Roles;

namespace TNTechnology.Business.Models.User
{
    public class UserModel : BaseModel
    {
        public UserModel()
        {
            Roles = new List<RolesModel>();
        }

        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public AppEnums.Sex Sex { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public List<RolesModel> Roles { get; set; }
        public string Address { get; set; }
    }
}
