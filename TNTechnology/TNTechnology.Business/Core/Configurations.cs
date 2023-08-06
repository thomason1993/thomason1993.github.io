namespace TNTechnology.Business.Core
{
    public class Configurations
    {
        public static ConnectionStrings ConnectionStrings { get; set; }
        public static Jwt Jwt { get; set; }
        public static SendGrid? SendGrid { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Jwt
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
    }

    public class SendGrid
    {
        public string ApiKey { get; set; }
        public string SenderEmail { get; set; }
        public string DisplayName { get; set; }
    }
}
