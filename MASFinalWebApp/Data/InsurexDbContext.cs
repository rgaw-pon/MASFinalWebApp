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
        public DbSet<AutocascoInsurance> AutocascoInsurances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InsuranceAgreement> InsuranceAgreements { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Owner> Ownmers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SportDiscipline> SportDisciplines { get; set; }
        public DbSet<SportInsurance> SportInsurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Insurance>().ToTable("Insurance");
            modelBuilder.Entity<InsurancePackage>().ToTable("InsurancePackage");
            modelBuilder.Entity<InsurancesInPackages>().ToTable("InsurancesInPackages");
            modelBuilder.Entity<InsurancesInPackages>().HasKey(i => new { i.InsuranceID, i.InsurancePackageID });
            modelBuilder.Entity<AutocascoInsurance>().ToTable("AutocascoInsurance");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<InsuranceAgreement>().ToTable("InsuranceAgreement");
            modelBuilder.Entity<InsuranceAgreement>().HasKey(i => new { i.InsuranceID, i.InsurancePackageID, i.ClientID });
            modelBuilder.Entity<Insurer>().ToTable("Insurer");
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<SportDiscipline>().ToTable("SportDiscipline");
            modelBuilder.Entity<SportInsurance>().ToTable("SportInsurance");
            modelBuilder.Entity<PropertyInsurance>().ToTable("PropertyInsurance");

        }

    }
}
