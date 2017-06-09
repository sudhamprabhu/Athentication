using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthBLL.Entities
{
   

    /// <summary>
    /// A basic implementation for an application database context compatible with ASP.NET Identity 2 using
    /// <see cref="long"/> as the key-column-type for all entities.
    /// </summary>
    /// <remarks>
    /// This type depends on some other types out of this assembly.
    /// </remarks>
    public class AuthDbContext : IdentityDbContext<User, Role, long, Login, UserRole, Claim>
    {
        #region constructors and destructors

        public AuthDbContext()
            : base("ImsConnection")
        {
        }

        #endregion

        #region methods

        public static AuthDbContext Create()
        {
            return new AuthDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Map Entities to their tables.
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Claim>().ToTable("UserClaim");
            modelBuilder.Entity<Login>().ToTable("UserLogin");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");

            // Set AutoIncrement-Properties
            modelBuilder.Entity<User>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Claim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Role>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Override some column mappings that do not match our default
           // modelBuilder.Entity<MyUser>().Property(r => r.UserName).HasColumnName("Login");
           // modelBuilder.Entity<MyUser>().Property(r => r.PasswordHash).HasColumnName("Password");
        }

        #endregion
    }
}