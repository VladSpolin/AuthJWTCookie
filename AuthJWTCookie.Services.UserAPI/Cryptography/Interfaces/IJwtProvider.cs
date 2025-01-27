using AuthJWTCookie.Services.UserAPI.Models;

namespace AuthJWTCookie.Services.UserAPI.Cryptography.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
