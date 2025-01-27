using AuthJWTCookie.Services.UserAPI.Interfaces;
using AuthJWTCookie.Services.UserAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWTCookie.Services.UserAPI.Controllers
{
    
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IResult> Register(CreateUserDto createUserDto)
        {
            await _userService.CreateUserAsync(createUserDto);
            return Results.Ok();
        }

        [HttpPut]  
        public async Task<IResult> Login(LoginUserDto loginUserDto)
        {
            var token = await _userService.LoginAsync(loginUserDto);
            Response.Cookies.Append("lala", token);
            return Results.Ok();
        }

    }
}
