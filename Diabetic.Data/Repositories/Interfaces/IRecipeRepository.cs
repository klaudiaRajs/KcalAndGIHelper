using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        RecipeDTO GetRecipeById(int? id);
        IEnumerable<RecipeDTO> GetAllRecipes();
        IEnumerable<RecipeDTO> GetByMeal(int id);
        IEnumerable<RecipeDTO> GetNonDinnerRecipes();
        bool Create(Recipe recipe);
        bool AddIngredientsToRecipe(Recipe newRecipe, List<Recipe_Ingredients> ingredients);
        bool Remove(RecipeDTO recipe);
        List<Recipe_Ingredients> GetIngredientsByRecipe(int id);
        List<Recipe_Ingredients> GetIngredientsEntryForRecipeAndProduct(int recipeId, int productId);
        bool RemoveIngredientsForRecipe(List<Recipe_Ingredients> ingredients);
        bool Update(Recipe recipe);
        bool UpdateIngredientsForRecipe(Recipe currentRecipe, List<Recipe_Ingredients> toBeUpdated);
        bool CreateRecipeIfNotExistant(List<SelectionDTO> ingredients, int recipeId, string title, int recipeDayId);
        bool AssignRecipeToMeals(int id, int[] selectedMeals);
        bool UpsertIngredientToRecipe(RecipeDTO recipe, Recipe_Ingredients ingredient);
    }
}
