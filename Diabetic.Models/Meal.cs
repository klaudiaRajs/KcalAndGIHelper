namespace Diabetic.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MealRecipeId { get; set; }
    }
}
