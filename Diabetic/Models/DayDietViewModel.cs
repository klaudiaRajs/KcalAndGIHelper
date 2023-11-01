using Diabetic.Models.DTOs;

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
    }
}
