using AnimeList.Data.Access;
using AnimeList.Data.Entities.Auth;
using AnimeList.Web.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                    Role = user.Role
                };
            }

            return userLoginModel;

        }

        public async Task<UserEditRetrieveModel> SignUp(User user)
        {
            await _context.AddAsync(user);
            var hashedPassword = BCryptNet.HashPassword(user.PasswordHash);
            await _context.SaveChangesAsync();
			return new UserEditRetrieveModel() 
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = hashedPassword,
                Role = Roles.User
            };
        }

        public async Task<UserLoginModel> Logout(string username)
        {
            var user = _context.Set<UserEditRetrieveModel>().Where(u => u.UserName == username).FirstOrDefault();
            return new UserLoginModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                IsValid = false,
                PasswordHash = user.PasswordHash,
                Role = user.Role
            };

        }

        public async Task<UserEditRetrieveModel?> UpdateUser(UserEditRetrieveModel user)
        {
            _context.Set<UserEditRetrieveModel>().Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var result = _context.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            _context.Set<User>().Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
