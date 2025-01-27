using AuthJWTCookie.Services.UserAPI.Models;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;

namespace AuthJWTCookie.Services.UserAPI.Interfaces
{
    public interface IUserService
    {
         Task CreateUser(CreateUserDto userDto);
         Task<string> Login(LoginUserDto loginUserDto);
         Task<User> GetByEmail(string email);
    }
}
