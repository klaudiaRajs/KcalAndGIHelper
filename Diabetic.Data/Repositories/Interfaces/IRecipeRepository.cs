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
        bool AddIngredientsToRecipe(Recipe newRecipe, List<Recipe_Ingredients> ingredients);
        bool Remove(RecipeDto recipe);
        List<Recipe_Ingredients> GetIngredientsByRecipe(int id);
        List<Recipe_Ingredients> GetIngredientsEntryForRecipeAndProduct(int recipeId, int productId);
        bool RemoveIngredientsForRecipe(List<Recipe_Ingredients> ingredients);
        bool Update(Recipe recipe);
        bool UpdateIngredientsForRecipe(Recipe currentRecipe, List<Recipe_Ingredients> toBeUpdated);
        bool CreateRecipeIfNotExistant(List<SelectionDto> ingredients, int recipeId, string title, int recipeDayId);
        bool AssignRecipeToMeals(int id, int[] selectedMeals);
        bool UpsertIngredientToRecipe(RecipeDto recipe, Recipe_Ingredients ingredient);
    }
}
