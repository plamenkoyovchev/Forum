using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Models
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Post
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser User { get; set; }
    }
}
