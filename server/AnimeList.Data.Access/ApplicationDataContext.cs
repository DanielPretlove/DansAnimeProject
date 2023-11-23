using AnimeList.Data.Entities;
using AnimeList.Data.Entities.Auth;
using AnimeList.Seeders;
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
                UserSeeder.CreateUser(firstname: "Admin", lastname: "Admin", username: "Admin", email: "admin@gmail.com", emailConfirmed: "admin@gmail.com", roles: Roles.Admin, lockedEnabled: false, accessFailCount: 0),
                UserSeeder.CreateUser(firstname: "User", lastname: "User", username: "User", email: "user@gmail.com", emailConfirmed: "user@gmail.com", roles: Roles.User, lockedEnabled: false, accessFailCount: 0),
                UserSeeder.CreateUser(firstname: "Guest", lastname: "Guest", username: "Guest", email: "guest@gmail.com", emailConfirmed: "guest@gmail.com", roles: Roles.Guest, lockedEnabled: false, accessFailCount: 0));
        }
    }
}
