using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class DayToDayDiaryViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<MealDTO> MealsWithIngredients { get; set; } = new List<MealDTO>();
        public DateTime GetDate { get; set; } = DateTime.Now;
        public int TotalKcalsForDay
        {
            get
            {
                int total = 0;
                foreach (MealDTO item in MealsWithIngredients)
                {
                    foreach (IngredientDTO ingredient in item.Ingredients)
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
                int total = 0;
                foreach (MealDTO item in MealsWithIngredients)
                {
                    foreach (IngredientDTO ingredient in item.Ingredients)
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
            List<MealDTO> items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (MealDTO item in items)
            {
                foreach (IngredientDTO ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Kcals;
                }
            }
            return total;
        }

        public int TotalGLPerMeal(int id)
        {
            int total = 0;
            List<MealDTO> items = MealsWithIngredients.Where(a => a.MealId == id).ToList();
            foreach (MealDTO item in items)
            {
                foreach (IngredientDTO ingredient in item.Ingredients)
                {
                    total += (int)ingredient.Gl;
                }
            }
            return total;
        }
    }
}
