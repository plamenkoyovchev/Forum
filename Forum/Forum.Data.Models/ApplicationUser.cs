namespace Forum.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Thread> threads;
        private ICollection<Post> posts;
        private ICollection<Comment> comments;

        public ApplicationUser()
        {
            this.threads = new HashSet<Thread>();
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Thread> Threads
        {
            get
            {
                return this.threads;
            }
            set
            {
                this.threads = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public string AboutMe { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
