using Microsoft.IdentityModel.Tokens;
using MVC_ThomasMore.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MVC_ThomasMore.Helper
{
    public static class Token
    {
        public static MySettings? MySettings;

        public static JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(MySettings.Secret));

            var token = new JwtSecurityToken(
                issuer: MySettings.ValidIssuer,
                audience: MySettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
