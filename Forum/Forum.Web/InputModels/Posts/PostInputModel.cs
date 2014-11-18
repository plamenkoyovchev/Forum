namespace Forum.Web.InputModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PostInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public long ThreadId { get; set; }

        [DefaultValue("false")]
        public bool? IsBestAnswer { get; set; }

        [DefaultValue("false")]
        public bool? IsImportant { get; set; }
    }
}