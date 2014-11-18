namespace Forum.Data.Models
{
    using ForumSystem.Data.Common.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post:IDeletableEntity
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        [Index]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [DefaultValue("false")]
        public bool IsBestAnswer { get; set; }

        [DefaultValue("false")]
        public bool IsImportant { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTime? DeletedOn
        {
            get;
            set;
        }
    }
}
