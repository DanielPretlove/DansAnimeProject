using AnimeList.Data.Access;
using AnimeList.Data.Entities.Auth;
using AnimeList.Web.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;


namespace AnimeList.Application.Services.Auth
{
    public class UserService
    {

        // login = username, password where password returns a cookie
        // signup = username, email, password
        // logout // set all of them to empty maybe 
        // add user based on role
        // update user based on role
        // delete user based on role
        private readonly ApplicationDataContext _context;
        
        public UserService(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<UserLoginModel> Login(string username, string password)
        {
            var user = _context.Set<User>().Where(u => u.UserName == username).FirstOrDefault();
            var userLoginModel = new UserLoginModel{ IsValid = BCryptNet.Verify(password, user.PasswordHash) };
            if (user == null || password == null || username == null || userLoginModel.IsValid == false)
            {
                userLoginModel = new UserLoginModel()
                {

                };
            }

            else
            {
                userLoginModel =  new UserLoginModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsValid = BCryptNet.Verify(password, user.PasswordHash),
                    PasswordHash = user.PasswordHash,
                    Role = user.Role
                };
            }

            return userLoginModel;

        }

        public async Task SignUp(string username, string password)
        {

        }

        public async Task Logout(string username, string password)
        {

        }

        public async Task AddNewUser(string username, string password)
        {

        }

        public async Task UpdateUser(string username, string password)
        {

        }

        public async Task DeleteUser(string username, string password)
        {

        }
    }
}
