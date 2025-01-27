using AuthJWTCookie.Services.UserAPI.Cryptography.Interfaces;
using AuthJWTCookie.Services.UserAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AuthJWTCookie.Services.UserAPI.Cryptography
{
    public class JwtProvider: IJwtProvider
    {
        
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {

            Claim[] claims = [new("userId", user.Id.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:claims,
                signingCredentials:signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHoures));

            var tokenVakue = new JwtSecurityTokenHandler().WriteToken(token);
            
            return tokenVakue;
        }
    }
}
