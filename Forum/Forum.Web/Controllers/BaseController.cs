namespace Forum.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
using Forum.Data.Models;
    using System.Web.Routing;
using Forum.Data.Common.Repository;

    public class BaseController : Controller
    {
        private IRepository<ApplicationUser> users;

        public BaseController(IRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        protected ApplicationUser UserProfile { get; private set; }

        protected string CurrentUserId
        {
            get
            {
                return this.User.Identity.GetUserId();
            }
        }

        protected bool IsCurrentUserAuthenticated
        {
            get
            {
                return this.User.Identity.IsAuthenticated;
            }
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}