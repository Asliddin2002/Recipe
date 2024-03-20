using System.ComponentModel.DataAnnotations;

namespace WAD_RecipeBook_12247.Models
{
    // StudentId 12247
    public class Recipe
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Instractions is required")]
        public string? Instructions { get; set; }

    }
}
