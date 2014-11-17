namespace Forum.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
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
    }
}