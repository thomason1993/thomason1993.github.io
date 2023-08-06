using System.ComponentModel.DataAnnotations.Schema;
using TNTechnology.Entity.Base;

namespace TNTechnology.Entity.Tables
{
    [Table("CategoryNews")]
    public class CategoryNews : BaseEntity
    {
        public string FullName { get; set; }
        public string SlugName { get; set; }
        public string MainImage { get; set; }
        public int LayoutIndex { get; set; }
        public string Language { get; set; }
        public long? LanguageDefaultId { get; set; }
        public string? Description { get; set; }
        public long? ParentId { get; set; }
    }
}
