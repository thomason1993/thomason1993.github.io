using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TNTechnology.Business.Authorization;
using TNTechnology.Business.Core;
using TNTechnology.Business.Models.Admin;
using TNTechnology.Business.Services.Interfaces;

namespace TNTechnology.Business.Services
{
    public class JwtUtilsService : IJwtUtilsService
    {
        public string GenerateToken(AdminModel model)
        {
            // generate token that is valid for 7 days
            var issuer = Configurations.Jwt.Issuer;
            var audience = Configurations.Jwt.Audience;
            var key = Encoding.ASCII.GetBytes(Configurations.Jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(AppClaimTypes.IdentityClaim, model.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }

        public int? ValidateToken(string? token)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configurations.Jwt.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var modelId = int.Parse(jwtToken.Claims.First(x => x.Type == AppClaimTypes.IdentityClaim).Value);

                // return user id from JWT token if validation successful
                return modelId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
