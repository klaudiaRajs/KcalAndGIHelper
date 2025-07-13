using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Diabetic.Models.Helpers;

namespace Diabetic.Data.Repositories
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext db) : base(db)
        {
        }

        public bool AddIngredientsToRecipe(Recipe newRecipe, List<Recipe_Ingredients> ingredients)
        {
            try
            {
                _db.Recipe_Ingredients.AddRange(ingredients);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AssignRecipeToMeals(int id, int[] selectedMeals)
        {
            try
            {
                foreach (int ingredient in selectedMeals)
                {
                    MealRecipe entity = new MealRecipe { MealsId = ingredient, RecipesId = id };
                    _db.MealRecipes.Add(entity);
                }

                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpsertIngredientToRecipe(RecipeDto recipe, Recipe_Ingredients ingredient)
        {
            try
            {
                Recipe? recipeEntity = _db.Recipes.FirstOrDefault(a => a.Id == recipe.Id);
                Recipe_Ingredients? recipeIngredient =
                    _db.Recipe_Ingredients.FirstOrDefault(a =>
                        a.ProductId == ingredient.ProductId && a.RecipeId == recipe.Id);
                if (recipeEntity != null)
                {
                    ingredient.RecipeId = recipeEntity.Id;
                    if (recipeIngredient != null)
                    {
                        recipeIngredient.Amount = ingredient.Amount;
                        _db.Recipe_Ingredients.Update(recipeIngredient);
                    }
                    else
                    {
                        _db.Recipe_Ingredients.Add(ingredient);
                    }
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(Recipe recipe)
        {
            try
            {
                _db.Recipes.Add(recipe);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateRecipeIfNotExistant(List<SelectionDto> ingredients, int recipeId, string title,
            int recipeDayId)
        {
            try
            {
                List<int> products = ingredients.Select(a => a.Id).ToList();
                List<int> grams = ingredients.Select(a => a.Grams).ToList();

                var recipeIdsWithTheSameAmountOfProducts = _db.Recipe_Ingredients
                    .GroupBy(a => a.RecipeId, (a, b) => new { RecipeId = a, NumberOfProducts = b.Count() })
                    .Where(x => x.NumberOfProducts == products.Count() && x.RecipeId != recipeDayId).ToList();

                List<int> newRecipeIdsWithTheSameAmountOfProducts =
                    recipeIdsWithTheSameAmountOfProducts.Select(a => a.RecipeId).ToList();

                List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Where(a =>
                    products.Contains(a.ProductId) && grams.Contains(a.Amount) && a.RecipeId != recipeId).ToList();

                List<Recipe_Ingredients> recipeIngredietWithTheSameAmountOfProducts = _db.Recipe_Ingredients
                    .Where(a => newRecipeIdsWithTheSameAmountOfProducts.Contains(a.RecipeId)).ToList();

                List<RecipeDto> fullRecipes = new List<RecipeDto>();
                foreach (Recipe_Ingredients recipe in recipeIngredietWithTheSameAmountOfProducts)
                {
                    if (!fullRecipes.Where(a => a.Id == recipe.RecipeId).Any())
                    {
                        fullRecipes.Add(GetRecipeById(recipe.RecipeId));
                    }
                }

                int? extractedRecipeId = null;
                foreach (RecipeDto recipe in fullRecipes)
                {
                    foreach (IngredientDto ingredient in recipe.Ingredients)
                    {
                        if (!products.Contains(ingredient.ProductId))
                        {
                            extractedRecipeId = null;
                            break;
                        }
                        else
                        {
                            extractedRecipeId = recipe.Id;
                        }
                    }
                    if (extractedRecipeId != null)
                    {
                        break;
                    }
                }

                if (extractedRecipeId != null)
                {
                    Day_Recipe? dietDay = _db.Day_Recipes.FirstOrDefault(a => a.Id == recipeDayId);
                    if (dietDay != null)
                    {
                        switch (ingredients.FirstOrDefault().MealId)
                        {
                            case 1:
                                dietDay.BreakfastRecipeId = extractedRecipeId;
                                break;
                            case 2:
                                dietDay.LunchRecipeId = extractedRecipeId;
                                break;
                            case 3:
                                dietDay.DinnerRecipeId = extractedRecipeId;
                                break;
                            case 4:
                                dietDay.SnackRecipeId = extractedRecipeId;
                                break;
                            case 5:
                                dietDay.SupperRecipeId = extractedRecipeId;
                                break;
                        }

                        _db.Day_Recipes.Update(dietDay);
                        _db.SaveChanges();
                    }
                }
                else
                {
                    string name = title + "-Copy";
                    Recipe recipe = new Recipe { Name = name };
                    _db.Recipes.Add(recipe);
                    _db.SaveChanges();

                    List<Recipe_Ingredients> ingredientsToAdd = new List<Recipe_Ingredients>();
                    foreach (SelectionDto itm in ingredients)
                    {
                        ingredientsToAdd.Add(new Recipe_Ingredients()
                            { ProductId = itm.Id, Amount = itm.Grams, RecipeId = recipe.Id });
                    }

                    _db.Recipe_Ingredients.AddRange(ingredientsToAdd);
                    _db.SaveChanges();

                    Day_Recipe? dietDay = _db.Day_Recipes.FirstOrDefault(a => a.Id == recipeDayId);
                    switch (ingredients.FirstOrDefault().MealId)
                    {
                        case 1:
                            dietDay.BreakfastRecipeId = recipe.Id;
                            break;
                        case 2:
                            dietDay.LunchRecipeId = recipe.Id;
                            break;
                        case 3:
                            dietDay.DinnerRecipeId = recipe.Id;
                            break;
                        case 4:
                            dietDay.SnackRecipeId = recipe.Id;
                            break;
                        case 5:
                            dietDay.SupperRecipeId = recipe.Id;
                            break;
                    }

                    _db.Day_Recipes.Update(dietDay);
                    _db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                //TODO zrobić logowanie
                return false;
            }
        }

        public IEnumerable<RecipeDto> GetAllRecipes()
        {
            try
            {
                List<RecipeDto> recipes = new List<RecipeDto>();
                List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product)
                    .ToList();

                foreach (Recipe_Ingredients item in result)
                {
                    RecipeDto? recipe = recipes.FirstOrDefault(a => a.Id == item.RecipeId);
                    if (recipe != null)
                    {
                        recipe.Ingredients.Add(new IngredientDto
                            { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item) });
                    }
                    else
                    {
                        RecipeDto newRecipe = new RecipeDto();
                        newRecipe.Id = item.RecipeId;
                        newRecipe.Ingredients.Add(new IngredientDto
                            { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item) });
                        newRecipe.Name = item.Recipe.Name;
                        recipes.Add(newRecipe);
                    }
                }
                return recipes;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<RecipeDto>();
            }
        }

        public IEnumerable<RecipeDto> GetByMeal(int id)
        {
            List<int> relation = _db.MealRecipes.Where(c => c.MealsId == 3).Select(a => a.RecipesId).ToList();
            IEnumerable<RecipeDto> recipes = GetAllRecipes().Where(a => relation.Contains(a.Id)); 
            foreach (RecipeDto recipe in recipes)
            {
                recipe.Name += $" ({recipe.TotalKcal}kcal, {recipe.TotalGl})";
            }
            return recipes;
        }

        public List<Recipe_Ingredients> GetIngredientsByRecipe(int id)
        {
            try
            {
                return _db.Recipe_Ingredients.Include(a => a.Product).Where(a => a.RecipeId == id).ToList();
            }
            catch (Exception ex)
            {
                return new List<Recipe_Ingredients>();
            }
        }

        public List<Recipe_Ingredients> GetIngredientsEntryForRecipeAndProduct(int recipeId, int productId)
        {
            try
            {
                return _db.Recipe_Ingredients.Where(a => a.RecipeId == recipeId && a.ProductId == productId).ToList();
            }
            catch (Exception ex)
            {
                return new List<Recipe_Ingredients>();
            }
        }

        public IEnumerable<RecipeDto> GetNonDinnerRecipes()
        {
            try
            {
                List<int> relation = _db.MealRecipes.Where(c => c.MealsId == 3).Select(a => a.RecipesId).ToList();
                IEnumerable<RecipeDto> recipes = GetAllRecipes().Where(a => !relation.Contains(a.Id)); 
                
                foreach (RecipeDto recipe in recipes)
                {
                    recipe.Name += $" ({recipe.TotalKcal}kcal, {recipe.TotalGl})";
                }

                return recipes;
            }
            catch (Exception e)
            {
                return new List<RecipeDto>();
            }
        }

        public RecipeDto GetRecipeById(int? id)
        {
            if (id == null)
            {
                return new RecipeDto();
            }
            RecipeDto recipe = new RecipeDto();
            recipe.Id = (int)id;
            List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product)
                .Where(a => a.RecipeId == id).ToList();

            foreach (Recipe_Ingredients item in result)
            {
                recipe.Id = item.RecipeId;
                recipe.Name = item.Recipe.Name;
                recipe.Ingredients.Add(new IngredientDto
                    { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item) });
            }
            return recipe;
        }

        public bool Remove(RecipeDto recipe)
        {
            try
            {
                Recipe? result = _db.Recipes.FirstOrDefault(a => a.Id == recipe.Id);
                IEnumerable<MealRecipe> mealRecipes = _db.MealRecipes.Where(a => a.RecipesId == recipe.Id);
                if (result == null)
                {
                    return false;
                }
                
                _db.MealRecipes.RemoveRange(mealRecipes);
                _db.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveIngredientsForRecipe(List<Recipe_Ingredients> ingredients)
        {
            try
            {
                _db.Recipe_Ingredients.RemoveRange(ingredients);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Recipe recipe)
        {
            try
            {
                _db.Recipes.Update(recipe);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateIngredientsForRecipe(Recipe currentRecipe, List<Recipe_Ingredients> toBeUpdated)
        {
            try
            {
                _db.UpdateRange(toBeUpdated);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
