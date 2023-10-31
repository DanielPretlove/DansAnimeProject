﻿using AnimeList.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        }
    }
}
