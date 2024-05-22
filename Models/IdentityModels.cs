using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using IzimpisiApplicationsOffice.Models.UserFields;
using IzimpisiApplicationsOffice.Models.Applications;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IzimpisiApplicationsOffice.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public bool HasApplied {  get; set; } = false;
        public virtual SchoolBackground SchoolBackground { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
        public virtual ICollection<Application> Application { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<SchoolBackground> SchoolBackgrounds { get; set; }
        public DbSet<SchoolRecords> SchoolRecords { get; set; }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Courses> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method to set up Identity-related configurations

            // Configure the relationships between ApplicationUser and PersonalInfo
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(u => u.PersonalInfo)
                .WithRequired(pi => pi.ApplicationUser)
                .WillCascadeOnDelete();

            // Configure the relationships between ApplicationUser and SchoolBackground
            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(u => u.SchoolBackground)
                .WithRequired(sb => sb.ApplicationUser)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SchoolRecords>()
                .HasRequired(s => s.SchoolBackground) // SchoolRecord must have one school background
                .WithMany(u => u.SchoolRecords) // Schoo background can have many SchoolRecords
                .HasForeignKey(s => s.ApplicationUserId); 

            modelBuilder.Entity<Application>()
                .HasRequired(s => s.ApplicationUser) // SchoolRecord must have one school background
                .WithMany(u => u.Application) // Schoo background can have many SchoolRecords
                .HasForeignKey(s => s.ApplicationUserId);
        }
    }
    }