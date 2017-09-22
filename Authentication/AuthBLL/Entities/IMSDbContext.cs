using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using AuthBLL.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuthBLL.Entities
{
    public class IMSDbContext : IMSDbEntities
    {
        public IMSDbContext():base("ImsConnection")
        {
        }
        public static IMSDbContext Create()
        {
            return new IMSDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var conventions = new PluralizingTableNameConvention();
        //    var conventions2 = new PluralizingEntitySetNameConvention();
        //    modelBuilder.Conventions.Remove(conventions2);
        //    modelBuilder.Conventions.Remove(conventions);
            
        //    // Map Entities to their tables.
        //    modelBuilder.Entity<Organization>().ToTable("Organization");

           
        //    // Override some column mappings that do not match our default
        //    // modelBuilder.Entity<MyUser>().Property(r => r.UserName).HasColumnName("Login");
        //    // modelBuilder.Entity<MyUser>().Property(r => r.PasswordHash).HasColumnName("Password");
        //}

    }
}
