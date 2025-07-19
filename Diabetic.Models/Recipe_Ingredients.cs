using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Models
{
    public class Recipe_Ingredients : IIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
