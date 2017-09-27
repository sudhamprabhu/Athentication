using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using AuthBLL.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuthBLL.Entities
{

    // string ConnectionStringName
    public class IMSDbContext : IMSEntities
    {
        public IMSDbContext():base("ImsConnection")
        {
        }
        public static IMSDbContext Create()
        {
            return new IMSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Organization>().ToTable("Organization");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<Role>().ToTable("UserRole");

            //modelBuilder.Entity<User>()
            //.HasMany(n => n.Organization)
            //.WithRequired() // <- no param because not exposed end of relation,
            //                // nc => nc.News would throw an exception
            //                // because nc.News is in the base class
            //.Map(a => a.MapKey("NewsId"));
        }

    }
}
