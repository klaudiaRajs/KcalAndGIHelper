using Diabetic.Models.DTOs;
using Xunit.Abstractions;

namespace Diabetic.Models
{
    public class DayToDayDiaryViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<MealDTO> MealsWithIngredients { get; set; }
        public int TotalKcalsForDay
        {
            get
            {
                var total = 0;
                foreach (var item in MealsWithIngredients)
                {
                    foreach (var ingredient in item.Ingredients)
                    {
                        total += (int)ingredient.Kcals;
                    }
                }
                return total;
            }
        }

        public int TotalGLForDay
        {
            get
            {
                var total = 0;
                foreach (var item in MealsWithIngredients)
                {
                    foreach (var ingredient in item.Ingredients)
                    {
                        total += (int)ingredient.GL;
                    }
                }
                return total;
            }
        }

        public int TotalKcalsPerMeal(int id)
        {
            var total = 0;
            var items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (var item in items)
            {
                foreach (var ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Kcals;
                }
            }
            return total;
        }

        public int TotalGLPerMeal(int id)
        {
            var total = 0;
            var items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (var item in items)
            {
                foreach (var ingredient in item.Ingredients)
                {
                    total += (int)ingredient.GL;
                }
            }
            return total;
        }
    }
}
