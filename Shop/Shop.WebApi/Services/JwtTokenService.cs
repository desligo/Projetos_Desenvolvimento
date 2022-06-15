using Microsoft.IdentityModel.Tokens;
using Shop.WebApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.WebApi.Services
{
    public static class JwtTokenService
    {
        public static string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var keyJwt = Encoding.UTF8.GetBytes(Settings.Secret);
            
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                                       
                }),
                Expires = DateTime.UtcNow.AddHours(2),

               SigningCredentials = new SigningCredentials (new SymmetricSecurityKey(keyJwt), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
