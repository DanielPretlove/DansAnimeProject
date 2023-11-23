using AnimeList.Data.Entities;
using AnimeList.Data.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Access
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions options) : base(options) { }
        public static string Password { get; set; } = "Test@123";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dataEntity = Assembly
                    .GetAssembly(typeof(DataEntitiy))
                    .GetTypes()
                    .Where(a => a.BaseType == typeof(DataEntitiy));
            
            foreach (var entityType in dataEntity)
            {
                modelBuilder.Entity(entityType);
            }

            modelBuilder.Entity<User>().HasData(
                CreateUser(firstname: "Admin", lastname: "Admin", username: "Admin", email: "admin@gmail.com", emailConfirmed: "admin@gmail.com", passwordhash: Password,  roles: Roles.Admin, lockedEnabled: false, accessFailCount: 0),
                CreateUser(firstname: "User", lastname: "User", username: "User", email: "user@gmail.com", emailConfirmed: "user@gmail.com", passwordhash: Password, roles: Roles.User, lockedEnabled: false, accessFailCount: 0),
                CreateUser(firstname: "Guest", lastname: "Guest", username: "Guest", email: "guest@gmail.com", emailConfirmed: "guest@gmail.com", passwordhash: Password, roles: Roles.Guest, lockedEnabled: false, accessFailCount: 0));
        }

        public static User CreateUser(string firstname, string lastname, string username, string email, string emailConfirmed, string passwordhash, Roles roles, bool lockedEnabled, int accessFailCount)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                UserName = username,
                Email = email,
                EmailConfirmed = emailConfirmed,
                PasswordHash = HashPassword(passwordhash),
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
