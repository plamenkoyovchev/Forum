namespace Forum.Web.Controllers
{
    using Forum.Data.Common.Repository;
    using Forum.Data.Models;
    using Forum.Web.Models.Posts;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IRepository<Post> posts;

        public HomeController(IRepository<Post> posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            var posts = this.posts.All().Select(PostViewModel.FromPost);

            return this.View(posts);
        }
    }
}