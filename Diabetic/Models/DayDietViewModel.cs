using Diabetic.Models.DTOs;
using Diabetic.Models.Helpers;

namespace Diabetic.Models
{
    public class DayDietViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DayDietDTO RecipesForDay { get; set; } = new DayDietDTO();
        public IEnumerable<DayDietDTO> Days { get; set; }

        public IEnumerable<RecipeDTO> Recipes { get; set; } = new List<RecipeDTO>();
        public IEnumerable<RecipeDTO> Breakfasts { get; set; } = new List<RecipeDTO>();
        public IEnumerable<RecipeDTO> Dinners { get; set; } = new List<RecipeDTO>();
        public int SelectedKcals { get; set; } = 0;
        public int SelectedGL { get; set; } = 0;

        public int SetTotalKcals()
        {
            SelectedKcals += (int)this.RecipesForDay.Breakfast?.TotalKcal; 
            SelectedKcals += (int)this.RecipesForDay.Lunch.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Dinner.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Snack.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Supper.TotalKcal;
            return SelectedKcals; 
        }
        public int SetTotalGL()
        {
            SelectedGL += (int)this.RecipesForDay.Breakfast.TotalGL;
            SelectedGL += (int)this.RecipesForDay.Lunch.TotalGL;
            SelectedGL += (int)this.RecipesForDay.Dinner.TotalGL;
            SelectedGL += (int)this.RecipesForDay.Snack.TotalGL;
            SelectedGL += (int)this.RecipesForDay.Supper.TotalGL;
            return SelectedGL;
        }

        public List<IngredientDTO> IngredientsForShoppingList { get; set; } = new List<IngredientDTO>();
        public bool test { get; set; }
        public List<int> SelectedDaysIds { get; set; }
        public ErrorPageDTO ShoppingDaysNotSelected { get; set; } = new ErrorPageDTO
        {
            Title = HelperErrorMessages.PL_ERROR_MESSAGE_TITLE,
            Body = HelperErrorMessages.PL_SHOPPING_LIST_NO_DAYS_SELECTED
        };
    }
}
