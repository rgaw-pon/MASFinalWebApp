using MASFinalWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASFinalWebApp
{
    public class InsurexDbContext : DbContext
    {
        public InsurexDbContext(DbContextOptions<InsurexDbContext> options) : base(options)
        {
        }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsurancePackage> InsurancePackages { get; set; }
        public DbSet<InsurancesInPackages> InsurancesInPackages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Insurance>().ToTable("Insurance");
            modelBuilder.Entity<InsurancePackage>().ToTable("InsurancePackage");
            modelBuilder.Entity<InsurancesInPackages>().ToTable("InsurancesInPackages");
            modelBuilder.Entity<InsurancesInPackages>().HasKey(i => new { i.InsuranceID, i.InsurancePackageID });


        }

    }
}
