using AuthJWTCookie.Services.UserAPI.Models;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;

namespace AuthJWTCookie.Services.UserAPI.Interfaces
{
    public interface IUserService
    {
         Task CreateUserAsync(CreateUserDto userDto);
         Task<string> LoginAsync(LoginUserDto loginUserDto);
         Task<User> GetByEmail(string email);
    }
}
