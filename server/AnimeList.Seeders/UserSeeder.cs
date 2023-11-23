using AnimeList.Data.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Seeders
{
    public static class UserSeeder
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
                PasswordHash = HashPassword("Test@123"),
                Role = roles,
                LockoutEnabled = lockedEnabled,
                AccessFailCount = accessFailCount
            };
        }

        public static string HashPassword(string password)
        {
            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            byte[] salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}
