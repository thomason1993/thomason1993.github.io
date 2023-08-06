using TNTechnology.Business.Core;

namespace TNTechnology.Business.Models.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public AppEnums.Status Status { get; set; }
        public DateTime DateCreate { get; set; }
        public long UserCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public long? UserModify { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public long? DeletedByUserId { get; set; }
    }
}
