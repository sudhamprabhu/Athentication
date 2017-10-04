using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using IMSBLL.Model;
using IMSBLL.Entities;

namespace IMSBLL.Entities
{

    // string ConnectionStringName
    public class IMSDbContext : IIMSEntities
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
            modelBuilder.HasDefaultSchema("Ims");
            modelBuilder.Entity<Organization>().ToTable("Organization");
           
            //modelBuilder.Entity<User>()
            //.HasMany(n => n.Organization)
            //.WithRequired() // <- no param because not exposed end of relation,
            //                // nc => nc.News would throw an exception
            //                // because nc.News is in the base class
            //.Map(a => a.MapKey("NewsId"));
        }

    }
}
