namespace Diabetic.Models
{
    public class MealRecipe
    {
        public int Id { get; set; }
        public int MealsId { get; set; }
        public int RecipesId { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Meal> Meals { get; set; }    
    }
}
