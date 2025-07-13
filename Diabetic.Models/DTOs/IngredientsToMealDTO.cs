namespace Diabetic.Models.DTOs
{
    public class IngredientsToMealDto
    {
        public IEnumerable<Meal> Meals { get; set; }
        public int SelectedMealId { get; set; }
        public int SelectedProductId { get; set; }
        public string ProductName { get; set; }
        public List<IngredientDto> Products { get; set; } = new List<IngredientDto>();
        public int Amount { get; set; }
        public string UserId { get; set; }
    }
}

