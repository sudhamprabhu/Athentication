using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace AuthBLL.Entities
{
   

    /// <summary>
    /// A basic implementation for an application database context compatible with ASP.NET Identity 2 using
    /// <see cref="long"/> as the key-column-type for all entities.
    /// </summary>
    /// <remarks>
    /// This type depends on some other types out of this assembly.
    /// </remarks>
    public class AuthDbContext : IdentityDbContext<UserDTO, RoleDTO, long, LoginDTO, UserRoleDTO, ClaimDTO>
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

           
            var conventions = new PluralizingTableNameConvention();
            modelBuilder.Conventions.Remove(conventions);
            // Map Entities to their tables.
            modelBuilder.Entity<UserDTO>().ToTable("User");
            modelBuilder.Entity<RoleDTO>().ToTable("Role");
            modelBuilder.Entity<ClaimDTO>().ToTable("UserClaim");
            modelBuilder.Entity<LoginDTO>().ToTable("UserLogin");
            modelBuilder.Entity<UserRoleDTO>().ToTable("UserRole");
           
            // Set AutoIncrement-Properties
            modelBuilder.Entity<UserDTO>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ClaimDTO>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RoleDTO>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Override some column mappings that do not match our default
            modelBuilder.Entity<UserDTO>().Property(r => r.Id).HasColumnName("Id");
           modelBuilder.Entity<UserDTO>().Property(r => r.OrganizationId).HasColumnName("OrganizationId");
        }

        #endregion
    }
}