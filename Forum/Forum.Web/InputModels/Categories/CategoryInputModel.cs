using System.ComponentModel.DataAnnotations;
namespace Forum.Web.InputModels.Categories
{
    public class CategoryInputModel
    {
        [Required]
        [StringLength(100,MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}