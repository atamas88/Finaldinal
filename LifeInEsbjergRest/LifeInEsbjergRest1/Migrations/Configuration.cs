//namespace LifeInEsbjergRest1.Migrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<LifeInEsbjergRest1.Models.ApplicationDbContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = true;

//            //***DO NOT REMOVE THIS LINE, 
//            //DATA WILL BE LOST ON A BREAKING SCHEMA CHANGE,
//            //TALK TO OTHER PARTIES INVOLVED IF THIS LINE IS CAUSING PROBLEMS
//            //AutomaticMigrationDataLossAllowed = true;
//        }

//        protected override void Seed(LifeInEsbjergRest1.Models.ApplicationDbContext context)
//        {
//            //  This method will be called after migrating to the latest version.

//            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//            //  to avoid creating duplicate seed data. E.g.
//            //
//            //    context.People.AddOrUpdate(
//            //      p => p.FullName,
//            //      new Person { FullName = "Andrew Peters" },
//            //      new Person { FullName = "Brice Lambson" },
//            //      new Person { FullName = "Rowan Miller" }
//            //    );
//            //
//        }
//    }
//}