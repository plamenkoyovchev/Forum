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

    using PagedList;
    using Forum.Web.Infrastructure.Sanitizer;

    public class ThreadController : BaseController
    {
        private readonly IRepository<Post> posts;
        private readonly IRepository<Thread> threads;
        private readonly ISanitizer sanitizer;
        private readonly IRepository<Category> categories;

        public ThreadController(IRepository<ApplicationUser> users, IRepository<Thread> threads, IRepository<Category> categories,
            IRepository<Post> posts, ISanitizer sanitizer)
            : base(users)
        {
            this.threads = threads;
            this.categories = categories;
            this.sanitizer = sanitizer;
            this.posts = posts;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var threads = this.threads.All().OrderByDescending(t => t.Id).Select(ThreadViewModel.FromThread);
            var model = new PagedList<ThreadViewModel>(threads, page, pageSize);

            return this.View(model);
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
        public ActionResult Details(long id, string url, int page = 1, int pageSize = 10)
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
                Content = sanitizer.Sanitize(thread.Content),
                AuthorName = thread.User.UserName
            };

            var threadPosts = new PagedList<Post>(thread.Posts, page, pageSize);
            threadDetail.Posts = threadPosts;

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

                var posts = this.posts.All().Include(u => u.User).Where(x => x.ThreadId == model.ThreadId);
                return this.PartialView("_PostsList", posts);
            }

            return this.PartialView("_PostAnswer", model);
        }

        public ActionResult GetPostsForPager(int page = 1, int pageSize = 10)
        {
            var posts = this.posts.All().OrderByDescending(p => p.Id);
            var model = new PagedList<Post>(posts, page, pageSize);

            return PartialView("_PostsPager", model);
        }
    }
}