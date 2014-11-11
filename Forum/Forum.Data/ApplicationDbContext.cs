namespace Forum.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Forum.Data.Migrations;
    using Forum.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}
