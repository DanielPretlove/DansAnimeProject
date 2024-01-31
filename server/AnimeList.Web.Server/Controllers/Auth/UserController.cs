using AnimeList.Application.Services.Auth;
using AnimeList.Data.Entities.Auth;
using AnimeList.Web.Shared.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AnimeList.Web.Server.Controllers.Auth
{
    public class UserController : BaseApiController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/login")]
        public async Task<UserLoginModel> Login(string username, string password)
        {
            var hashedPassword = BCryptNet.HashPassword(password);
            return await _userService.Login(username, hashedPassword);
        }

        [HttpPost("/signup")]
        public async Task<UserEditRetrieveModel> SignUp(User user)
        {
            return await _userService.SignUp(user);
        }

        [Authorize]
        [HttpPut("/updateProfile")]
        public async Task<UserEditRetrieveModel?> UpdateUserProfile(UserEditRetrieveModel user)
        {
            return await _userService.UpdateUser(user);
        }

        [Authorize]
        [HttpDelete("/deleteProfile")]
        public async Task<User> DeleteUserProfile(Guid id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
