using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Entities
{
    public class CompleteGPSUtilityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public CompleteGPSUtilityContext(DbContextOptions<CompleteGPSUtilityContext> options) : base(options)
        {
           
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Access> Accesses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetColumnType("decimal(9,6)");
            }
            // TODO: Fluent api
        }
    }
}
