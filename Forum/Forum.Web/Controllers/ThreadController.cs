namespace Forum.Web.Controllers
{
    using Forum.Data.Common.Repository;
    using Forum.Data.Models;
    using Forum.Web.InputModels.Threads;
    using Forum.Web.ViewModels.Threads;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ThreadController : BaseController
    {
        private readonly IRepository<Thread> threads;
        private readonly IRepository<Category> categories;

        public ThreadController(IRepository<Thread> threads, IRepository<Category> categories)
        {
            this.threads = threads;
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var threads = this.threads.All().Select(ThreadViewModel.FromThread);

            return this.View(threads);
        }

        [HttpGet]
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
    }
}