using Diabetic.Models.DTOs;

namespace Diabetic.Models
{
    public class RecipeViewModel : BaseViewModel
    {
        public RecipeDTO Recipe { get; set; } = new RecipeDTO();
        public List<RecipeDTO> Recipes { get; set; } = new List<RecipeDTO>();
        public List<SelectedCheckboxViewModel> SelectedCheckboxes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
