﻿using Car_Management.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car_Management.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<OverallService> OverallServices { get; set; }
        public DbSet<HackneyPermit>HackneyPermits { get; set; }
        public DbSet<Issurance> Issurances { get; set; }
        public DbSet< VehicleLicense> VehicleLicenses { get; set; }
        public DbSet<RoadWorthiness> RoadWorthinesses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
           //builder.Entity<Issurance>();
          // builder.Entity<VehicleLicense>();
          // builder.Entity<HackneyPermit>();
          // builder.Entity<RoadWorthiness>();
        }
    }
}