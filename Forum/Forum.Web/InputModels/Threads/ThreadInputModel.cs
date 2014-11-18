using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Forum.Web.InputModels.Threads
{
    public class ThreadInputModel
    {
        [Required]
        [StringLength(50,MinimumLength=10)]
        public string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 20)]
        public string Content { get; set; }

        [Required(ErrorMessage="Must choose category.")]
        public int CategoryId { get; set; }
    }
}