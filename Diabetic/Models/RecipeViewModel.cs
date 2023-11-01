using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class RecipeViewModel : BaseViewModel
    {
        public RecipeDTO Recipe { get; set; }
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public List<SelectedCheckboxViewModel> SelectedCheckboxes { get; set; }
    }
}
