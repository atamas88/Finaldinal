using LifeInEsbjergDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInEsbjergDAL.Context
{
    public class LifeInContext : DbContext
    {
        public LifeInContext() : base("LifeInEsbjergDB")
        {
            Database.SetInitializer(new LifeInContextInitializer());

            //Add this line to make json conversin happy.
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Company>().HasMany(c => c.Tags).WithMany();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
