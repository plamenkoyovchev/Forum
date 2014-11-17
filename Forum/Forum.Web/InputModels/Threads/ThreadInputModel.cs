using System.ComponentModel.DataAnnotations;
namespace Forum.Web.InputModels.Threads
{
    public class ThreadInputModel
    {
        [Required]
        [StringLength(50,MinimumLength=10)]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 20)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(ErrorMessage="Must choose category.")]
        public int CategoryId { get; set; }
    }
}