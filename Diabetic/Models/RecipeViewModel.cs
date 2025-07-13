using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Diabetic.Models
{
    public class RecipeViewModel : BaseViewModel
    {
        public RecipeDto Recipe { get; set; } = new RecipeDto();
        public List<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
        public List<SelectedCheckboxViewModel> SelectedCheckboxes { get; set; }
        public List<SelectedCheckboxViewModel> CurrentlySelectedCheckboxes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category CurrentCategory { get; set;  }
        public IEnumerable<SelectListItem> Meals { get; set; }
        public int[] SelectedMeals { get; set; }
        public bool IsIngredientBeingSwitched { get; set; } = false;
    }
}
