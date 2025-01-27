using AuthJWTCookie.Services.UserAPI.Models;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;
using AutoMapper;

namespace AuthJWTCookie.Services.UserAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<CreateUserDto, User>();
                config.CreateMap<LoginUserDto, User>();
                config.CreateMap<UserDto, User>();
                config.CreateMap<User, UserDto>();
            });
            return mappingConfig;
        }
    }
}
