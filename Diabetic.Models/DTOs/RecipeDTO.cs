using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Diabetic.Models.Helpers;

namespace Diabetic.Models.DTOs
{
    public class RecipeDto : BaseDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int MealId { get; set; }
        public int RecipeDayId { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
        public IEnumerable<Recipe_Ingredients> RecipeIngredients { get; set; } = new List<Recipe_Ingredients>();
        public bool IsNewRecipe { get; set; } = false;

        public IngredientDto GetIngredientByProduct(Product product, int amount)
        {
            return new IngredientDto
            {
                Product = product, 
                Amount = amount, 
                Gl = IndexHelper.GetGlOnIngredient(product, amount),
            };
        }
        
        [DisplayName("Selected amount of kcals")]
        public double TotalKcal
        {
            get => IndexHelper.GetKcalsForRecipe(this);
            set => IndexHelper.GetKcalsForRecipe(this);
        }
        public double TotalGl
        {
            get => IndexHelper.GetGlForRecipe(this);
            set => IndexHelper.GetGlForRecipe(this);
        }

        public bool Green { get; set; }
        public bool Orange { get; set; }
        public bool Red { get; set; }

        public bool IsGreen(int gI)
        {
            return gI <= MaxGreenGi;
        }

        public bool IsOrange(int gI)
        {
            return (gI > MaxGreenGi && gI <= MaxOrangeGi);
        }

        public bool IsRed(int gI)
        {
            return gI > MaxOrangeGi;
        }
    }
}
