using System.ComponentModel.DataAnnotations;

namespace Diabetic.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Recipe_Ingredients> RecipeIngredients { get; set; }
       // public ICollection<Meal> Meals { get; set; }
    }
}

