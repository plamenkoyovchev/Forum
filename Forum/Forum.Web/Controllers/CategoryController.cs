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

    public class CategoryController : BaseController
    {
        private IRepository<Category> categories;

        public CategoryController(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = this.categories.All().Select(CategoryViewModel.FromCategory);

            return View(categories);
        }

        [HttpGet]
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