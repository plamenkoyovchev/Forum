using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.ViewModels.Threads
{
    public class ThreadDetailViewModel
    {
        public ThreadDetailViewModel()
        {
            this.Posts = new HashSet<Post>();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}