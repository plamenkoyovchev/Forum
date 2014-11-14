namespace Forum.Data.Migrations
{
    using Forum.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            //TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //var user = new ApplicationUser
            //{
            //    Email = "plamenkooo@abv.bg",
            //    UserName = "plamen",
                
            //};
        }
    }
}
