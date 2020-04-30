using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Entities
{
    public class CompleteGPSUtilityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public CompleteGPSUtilityContext(DbContextOptions<CompleteGPSUtilityContext> options) : base(options)
        {
        }

        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppRole> AppRoles { get; set; }

        DbSet<Device> Devices { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Access> Accesses { get; set; }

    }
}
