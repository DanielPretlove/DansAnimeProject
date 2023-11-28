using AnimeList.Data.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
namespace AnimeList.Seeders
{
    public class UserSeeder
    {
        public static User CreateUser(string firstname, string lastname, string username, string email, string emailConfirmed, Roles roles, bool lockedEnabled, int accessFailCount)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                UserName = username,
                Email = email,
                EmailConfirmed = emailConfirmed,
                PasswordHash = BCryptNet.HashPassword("Test@123"),
                Role = roles,
                LockoutEnabled = lockedEnabled,
                AccessFailCount = accessFailCount
            };
        }
    }
}
