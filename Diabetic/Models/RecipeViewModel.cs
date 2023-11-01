using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class RecipeViewModel : BaseViewModel
    {
        public RecipeDTO Recipe { get; set; } = new RecipeDTO();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<SelectedCheckboxViewModel> SelectedCheckboxes { get; set; }
    }
}
