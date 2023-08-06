using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNTechnology.Entity.Tables
{
    [Table("Language")]
    public class Language
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public bool IsDefault { get; set; }
        public string Flag { get; set; }
    }
}
