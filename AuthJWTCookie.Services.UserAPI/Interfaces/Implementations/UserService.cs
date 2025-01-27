using AuthJWTCookie.Services.UserAPI.Cryptography.Interfaces;
using AuthJWTCookie.Services.UserAPI.DbContexts;
using AuthJWTCookie.Services.UserAPI.Models;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthJWTCookie.Services.UserAPI.Interfaces.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(ApplicationDbContext db, IMapper mapper, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _db = db;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = _passwordHasher.Generate(userDto.Password);
            _db.Users.Add(user);
            _db.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) throw new Exception();
            return _mapper.Map<User>(user);

        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            var user = await GetByEmail(loginUserDto.Email);
            var result = _passwordHasher.Verify(loginUserDto.Password, user.PasswordHash);
            if(!result) throw new Exception("Incorrect password!");
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
    }
}
