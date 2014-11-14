namespace Forum.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        [Index]
        public long Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser  User { get; set; }

        public virtual Vote Vote { get; set; }
    }
}
