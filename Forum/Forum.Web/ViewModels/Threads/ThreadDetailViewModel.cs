using Forum.Data.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.ViewModels.Threads
{
    public class ThreadDetailViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public PagedList<Post> Posts { get; set; }
    }
}