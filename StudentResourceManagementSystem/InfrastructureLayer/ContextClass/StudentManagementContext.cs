using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace InfrastructureLayer.ContextClass
{
    /// <summary>
    /// This is the database context class
    /// </summary>
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext() : base(GetDbContextOptions())
        {
        }
        public StudentManagementContext(DbContextOptions options)
             : base(options)
        {
        }

        /// <summary>
        /// This method enables lazy loading
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder instance</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


        private static DbContextOptions GetDbContextOptions()
        {
            return new DbContextOptionsBuilder().UseSqlServer(ConfigurationManager.AppSettings["ConnectionStrings:DefaultConnection"]).Options;
        }


        /// <summary>
        /// Method used to define the default values along with the relationships for the
        /// existing classes in the database
        /// </summary>
        /// <param name="modelBuilder">It helps in building the model for the database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryCode>().HasData(new CountryCode { Id = 1, PhoneCode = "INR", CountryName = "India" },
                                                       new CountryCode { Id = 2, PhoneCode = "CAD", CountryName = "Canada" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "paras", Email = "manchanda.paras0@gmail.com", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now },
                                                       new User { Id = 2, Name = "Aman", Email = "aman.behl0@gmail.com", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Student> Resource { get; set; }
        public DbSet<Student> User { get; set; }
        public DbSet<Student> CountryCode { get; set; }
    }
}
