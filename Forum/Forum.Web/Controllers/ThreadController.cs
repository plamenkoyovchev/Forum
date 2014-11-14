namespace Forum.Web.Controllers
{
    using Forum.Data.Common.Repository;
    using Forum.Data.Models;
    using Forum.Web.ViewModels.Threads;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ThreadController : Controller
    {
        private readonly IRepository<Thread> threads;

        public ThreadController(IRepository<Thread> threads)
        {
            this.threads = threads;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var threads = this.threads.All().Select(ThreadViewModel.FromThread);

            return this.View(threads);
        }
    }
}