using System.ComponentModel.DataAnnotations.Schema;
using TNTechnology.Business.Core;
using TNTechnology.Entity.Base;

namespace TNTechnology.Entity.Tables
{
    [Table("Admin")]
    public class Admin : BaseEntity
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public AppEnums.Sex? Sex { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
    }
}
