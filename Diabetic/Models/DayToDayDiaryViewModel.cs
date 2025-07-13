using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class DayToDayDiaryViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<MealDto> MealsWithIngredients { get; set; } = new List<MealDto>();
        public DateTime GetDate { get; set; } = DateTime.Now;
        public int TotalKcalsForDay
        {
            get
            {
                int total = 0;
                foreach (MealDto item in MealsWithIngredients)
                {
                    foreach (IngredientDto ingredient in item.Ingredients)
                    {
                        total += (int)ingredient.Kcals;
                    }
                }
                return total;
            }
        }

        public int TotalGlForDay
        {
            get
            {
                int total = 0;
                foreach (MealDto item in MealsWithIngredients)
                {
                    foreach (IngredientDto ingredient in item.Ingredients)
                    {
                        total += (int)ingredient.Gl;
                    }
                }
                return total;
            }
        }

        public int TotalKcalsPerMeal(int id)
        {
            int total = 0;
            List<MealDto> items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (MealDto item in items)
            {
                foreach (IngredientDto ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Kcals;
                }
            }
            return total;
        }

        public int TotalGlPerMeal(int id)
        {
            int total = 0;
            List<MealDto> items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (MealDto item in items)
            {
                foreach (IngredientDto ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Gl;
                }
            }
            return total;
        }
    }
}
