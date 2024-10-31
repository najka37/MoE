﻿using Microsoft.EntityFrameworkCore;
using Ministery_of_Education.Models.Entities;

namespace Ministery_of_Education.Data
{
    public class MinistryDbContext : DbContext
    {
        public MinistryDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
         // Ensure you have this DbSet
        public DbSet<UserRole> UserRoles { get; set; }

        // Also include other DbSets if needed
        public DbSet<User> Users { get; set; }
    }
    
}
