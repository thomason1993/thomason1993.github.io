using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNTechnology.Entity.Tables
{
    [Table("Admin_Roles")]
    public class Admin_Roles
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("AdminId")]
        public long AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        [ForeignKey("RolesId")]
        public long RolesId { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
