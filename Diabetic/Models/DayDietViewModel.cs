using Diabetic.Models.DTOs;
using Diabetic.Models.Helpers;

namespace Diabetic.Models
{
    public class DayDietViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DayDietDto RecipesForDay { get; set; } = new DayDietDto();
        public IEnumerable<DayDietDto> Days { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
        public IEnumerable<RecipeDto> Breakfasts { get; set; } = new List<RecipeDto>();
        public IEnumerable<RecipeDto> Dinners { get; set; } = new List<RecipeDto>();
        public int SelectedKcals { get; set; } = 0;
        public int SelectedGl { get; set; } = 0;

        public int SetTotalKcals()
        {
            SelectedKcals += (int)this.RecipesForDay.Breakfast?.TotalKcal; 
            SelectedKcals += (int)this.RecipesForDay.Lunch.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Dinner.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Snack.TotalKcal;
            SelectedKcals += (int)this.RecipesForDay.Supper.TotalKcal;
            return SelectedKcals; 
        }
        public int SetTotalGl()
        {
            SelectedGl += (int)this.RecipesForDay.Breakfast.TotalGl;
            SelectedGl += (int)this.RecipesForDay.Lunch.TotalGl;
            SelectedGl += (int)this.RecipesForDay.Dinner.TotalGl;
            SelectedGl += (int)this.RecipesForDay.Snack.TotalGl;
            SelectedGl += (int)this.RecipesForDay.Supper.TotalGl;
            return SelectedGl;
        }

        public List<IngredientDto> IngredientsForShoppingList { get; set; } = new List<IngredientDto>();
        public bool Test { get; set; }
        public List<int> SelectedDaysIds { get; set; }
        public ErrorPageDto ShoppingDaysNotSelected { get; set; } = new ErrorPageDto
        {
            Title = HelperErrorMessages.PlErrorMessageTitle,
            Body = HelperErrorMessages.PlShoppingListNoDaysSelected
        };
    }
}
