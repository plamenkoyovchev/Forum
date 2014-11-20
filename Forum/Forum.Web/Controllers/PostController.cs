using Forum.Data.Common.Repository;
using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    public class PostController : BaseController
    {
        private IRepository<ApplicationUser> users;

        public PostController(IRepository<ApplicationUser> users)
            : base(users)
        {

        }
    }
}