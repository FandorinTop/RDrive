using System;
using System.Collections.Generic;
using System.Text;
using RDrive.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RDrive.DataAccess.DataAccept
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,ApplicationRole,int>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Model> Models{ get; set; }
        public ApplicationDbContext()
        {

            //Database.EnsureCreated();
            //Database.Migrate();

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RDrive;Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
