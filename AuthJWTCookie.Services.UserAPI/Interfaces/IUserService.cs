using AuthJWTCookie.Services.UserAPI.Models.Dtos;

namespace AuthJWTCookie.Services.UserAPI.Interfaces
{
    public interface IUserService
    {
         Task CreateUser(CreateUserDto userDto);
    }
}
