using IzimpisiApplicationsOffice.Models.UserFields;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models
{
    public class DbContextIAO : DbContext
    {
        public DbContextIAO() : base("DbContextIAO") { }

        public DbSet<SchoolBackground> SchoolBackgrounds { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method to set up Identity-related configurations

            // Ignore Identity entities
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityUserRole>();

            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<ApplicationUser>()
                        .HasOptional(u => u.PersonalInfo) 
                        .WithRequired(pi => pi.ApplicationUser);

            modelBuilder.Entity<ApplicationUser>()
    .HasOptional(u => u.SchoolBackground) // ApplicationUser can have optional SchoolBackground
    .WithRequired(sb => sb.ApplicationUser);
        }
    }
}