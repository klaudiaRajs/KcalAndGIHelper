using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class DayToDayDiaryViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<MealDTO> MealsWithIngredients { get; set; }
        public int TotalKcalsPerMeal(int id)
        {
            var total = 0; 
            var items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach(var item in items)
            {
                foreach(var ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Kcals; 
                }
            }
            return total;
        }
    }
}
