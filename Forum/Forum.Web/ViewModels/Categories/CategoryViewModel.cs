namespace Forum.Web.ViewModels.Categories
{
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return cat => new CategoryViewModel
                {
                    Name = cat.Name,
                    Description = cat.Description
                };
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}