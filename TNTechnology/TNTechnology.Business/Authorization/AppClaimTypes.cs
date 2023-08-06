using System.Security.Claims;

namespace TNTechnology.Business.Authorization
{
    public class AppClaimTypes
    {
        public static string IdentityClaim => "id";

        public static string RoleCodeClaim => "role_code";

        public static string RolesClaim = ClaimTypes.Role;

        public static string TokenIdClaim => "token_id";

        public static string PolicyClaim => "policy";

        public static string EmailClaim => "email";

        public static string FullNameClaim => "fullNameClaim";

        public static string AvatarClaim => "avatarClaim";
    }

    public class AuthScheme
    {
        public const string MixJwtAndCookie = "Bearer,Cookies";

    }

    public class AuthPolicy
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
