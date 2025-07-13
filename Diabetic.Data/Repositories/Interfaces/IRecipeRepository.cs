using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        RecipeDto GetRecipeById(int? id);
        IEnumerable<RecipeDto> GetAllRecipes();
        IEnumerable<RecipeDto> GetByMeal(int id);
        IEnumerable<RecipeDto> GetNonDinnerRecipes();
        bool Create(Recipe recipe);
        bool AddIngredientsToRecipe(Recipe newRecipe, List<RecipeIngredients> ingredients);
        bool Remove(RecipeDto recipe);
        List<RecipeIngredients> GetIngredientsByRecipe(int id);
        List<RecipeIngredients> GetIngredientsEntryForRecipeAndProduct(int recipeId, int productId);
        bool RemoveIngredientsForRecipe(List<RecipeIngredients> ingredients);
        bool Update(Recipe recipe);
        bool UpdateIngredientsForRecipe(Recipe currentRecipe, List<RecipeIngredients> toBeUpdated);
        bool CreateRecipeIfNotExistant(List<SelectionDto> ingredients, int recipeId, string title, int recipeDayId);
        bool AssignRecipeToMeals(int id, int[] selectedMeals);
        bool UpsertIngredientToRecipe(RecipeDto recipe, RecipeIngredients ingredient);
    }
}
