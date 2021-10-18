using Data.Entities;
using Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InsuranceDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<HealthInsurance> HealthInsurances { get; set; }
        public virtual DbSet<MedicalInsurance> MedicalInsurances { get; set; }


        /// <summary>
        /// Over riding configure method to use connection string in class library
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5RRIONQ\\SQLSERVER;Initial Catalog=Insurance;Trusted_Connection=True;");
            }
        }
    }
}
