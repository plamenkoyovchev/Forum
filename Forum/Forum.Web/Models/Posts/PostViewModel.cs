namespace Forum.Web.Models.Posts
{
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class PostViewModel
    {
        public static Expression<Func<Post, PostViewModel>> FromPost
        {
            get
            {
                return post => new PostViewModel
                {
                    Title = post.Title,
                    Content = post.Content,
                    Username = post.User.UserName
                };
            }
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }
    }
}