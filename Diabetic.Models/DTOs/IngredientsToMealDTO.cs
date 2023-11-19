namespace Diabetic.Models.DTOs
{
    public class IngredientsToMealDTO
    {
        public IEnumerable<Meal> Meals { get; set; }
        public int SelectedMealId { get; set; }
        public int SelectedProductId { get; set; }
        public List<IngredientDTO> Products { get; set; } = new List<IngredientDTO>();
        public int Amount { get; set; }
    }
}
