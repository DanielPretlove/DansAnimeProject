using AnimeList.Application.Services.Auth;
using AnimeList.Web.Shared.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Web.Server.Controllers.Auth
{
    public class UserController : BaseApiController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<UserLoginModel> Login(string username, string password)
        {
            return await _userService.Login(username, password);
        }
    }
}
