using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_RecipeBook_12247.Models
{
    // StudentId 12247
    public class Ingredients
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Quantity { get; set; }

        public int? RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public Recipe? Recipe { get; set; }
    }
}
