
namespace Forum.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Thread
    {
        public Thread()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        [Index]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
