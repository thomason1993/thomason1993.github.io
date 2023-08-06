using System.ComponentModel;

namespace TNTechnology.Business.Core
{
    public class AppEnums
    {
        public enum Status
        {
            [Description("Lock")] Lock = -1,
            [Description("Inactive")] Inactive = 0,
            [Description("Active")] Active = 1,
            [Description("New")] New = 2,
            [Description("Doing")] Doing = 3,
            [Description("Pending")] Pending = 4,
            [Description("Done")] Done = 5,
            [Description("Closed")] Closed = 6,
            [Description("Seen")] Seen = 7,
        }

        public enum Sex
        {
            [Description("Female")] Female = 0,
            [Description("Male")] Male = 1,
            [Description("Other")] Other = 2
        }

        public enum DefaultImage
        {
            [Description("uploads/default-girl.png")] Girl,
            [Description("uploads/default-man.png")] Man,
            [Description("uploads/default-img.png")] Img,
            [Description("uploads/default-product.png")] Product,
        }
    }
}
