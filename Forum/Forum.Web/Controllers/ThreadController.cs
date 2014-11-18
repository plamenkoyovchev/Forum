namespace Forum.Web.Controllers
{
    using Forum.Data.Common.Repository;
    using Forum.Data.Models;
    using Forum.Web.InputModels.Posts;
    using Forum.Web.InputModels.Threads;
    using Forum.Web.ViewModels.Threads;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Data.Entity;

    public class ThreadController : BaseController
    {
        private readonly IRepository<Post> posts;
        private readonly IRepository<Thread> threads;
        private readonly IRepository<Category> categories;

        public ThreadController(IRepository<Thread> threads, IRepository<Category> categories, IRepository<Post> posts)
        {
            this.threads = threads;
            this.categories = categories;
            this.posts = posts;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var threads = this.threads.All().Select(ThreadViewModel.FromThread);

            return this.View(threads);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new ThreadInputModel();
            var categories = this.categories.All().Where(x => x.IsActive);
            ViewBag.CategoryDdl = new SelectList(categories, "Id", "Name");

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThreadInputModel model)
        {
            if (ModelState.IsValid)
            {
                var thread = new Thread
                {
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = model.CategoryId,
                    UserId = this.CurrentUserId
                };

                this.threads.Add(thread);
                this.threads.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryDdl = new SelectList(this.categories.All().Where(x => x.IsActive), "Id", "Name", model.CategoryId);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(long id, string url)
        {
            if (id < 0)
            {
                return HttpNotFound();
            }

            var thread = this.threads.GetById(id);

            if (thread == null)
            {
                return HttpNotFound();
            }

            var threadDetail = new ThreadDetailViewModel
            {
                Id = thread.Id,
                Title = thread.Title,
                Content = thread.Content,
                AuthorName = thread.User.UserName,
                Posts = thread.Posts
            };

            return this.View(threadDetail);
        }

        [HttpGet]
        [Authorize]
        public PartialViewResult PostAnswer(long threadId)
        {
            var model = new PostInputModel
            {
                ThreadId = threadId
            };

            return this.PartialView("_PostAnswer", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostAnswer(PostInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newPost = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    ThreadId = model.ThreadId,
                    UserId = this.CurrentUserId
                };

                this.posts.Add(newPost);
                this.posts.SaveChanges();

                var posts = this.posts.All().Include(u=>u.User).Where(x => x.ThreadId == model.ThreadId);
                return this.PartialView("_PostsList", posts);
            }

            return this.PartialView("_PostAnswer", model);
        }
    }
}