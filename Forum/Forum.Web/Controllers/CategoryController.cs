namespace Forum.Web.Controllers
{
    using Forum.Data.Common.Repository;
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Forum.Web.ViewModels.Categories;
    using Forum.Web.InputModels.Categories;
    using PagedList;

    public class CategoryController : BaseController
    {
        private IRepository<Category> categories;
        private IRepository<ApplicationUser> users;

        public CategoryController(IRepository<ApplicationUser> users, IRepository<Category> categories)
            : base(users)
        {
            this.categories = categories;
        }

        // GET: Category
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var categories = this.categories.All().OrderByDescending(x => x.Id).Select(CategoryViewModel.FromCategory);
            PagedList<CategoryViewModel> model = new PagedList<CategoryViewModel>(categories, page, pageSize);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CategoryInputModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newCat = new Category
                {
                    Name = model.Name,
                    Description = model.Description
                };

                this.categories.Add(newCat);
                this.categories.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}