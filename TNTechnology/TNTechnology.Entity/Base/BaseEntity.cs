using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TNTechnology.Business.Core;

namespace TNTechnology.Entity.Base
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public AppEnums.Status Status { get; set; }
        public DateTime DateCreate { get; set; }
        public long? UserCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public long? UserModify { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeletedByUserId { get; set; }
    }
}
