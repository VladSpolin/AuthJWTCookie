using AuthJWTCookie.Services.UserAPI.DbContexts;
using AuthJWTCookie.Services.UserAPI.Helpers;
using AuthJWTCookie.Services.UserAPI.Models;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;
using AutoMapper;

namespace AuthJWTCookie.Services.UserAPI.Interfaces.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(ApplicationDbContext db, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _db = db;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = _passwordHasher.Generate(userDto.Password);
            _db.Users.Add(user);
            _db.SaveChangesAsync();
        }
    }
}
