using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                foreach (var ingredient in selectedMeals)
                {
                    MealRecipe entity = new MealRecipe { MealsId = ingredient, RecipesId = id};
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

        public bool CreateRecipeIfNotExistant(List<SelectionDTO> ingredients, int recipeId, string title, int recipeDayId)
        {
            try
            {
                var products = ingredients.Select(a => a.Id).ToList();
                var grams = ingredients.Select(a => a.Grams).ToList();

                var recipeIdsWithTheSameAmountOfProducts = _db.Recipe_Ingredients.GroupBy(a => a.RecipeId, (a, b) => new { RecipeId = a, NumberOfProducts = b.Count() }).Where(x => x.NumberOfProducts == products.Count() && x.RecipeId != recipeDayId).ToList();

                var newRecipeIdsWithTheSameAmountOfProducts = recipeIdsWithTheSameAmountOfProducts.Select(a => a.RecipeId).ToList();

                var result = _db.Recipe_Ingredients.Where(a => products.Contains(a.ProductId) && grams.Contains(a.Amount) && a.RecipeId != recipeId).ToList();

                var recipeIngredietWithTheSameAmountOfProducts = _db.Recipe_Ingredients.Where(a => newRecipeIdsWithTheSameAmountOfProducts.Contains(a.RecipeId)).ToList();

                List<RecipeDTO> fullRecipes = new List<RecipeDTO>();
                foreach (var recipe in recipeIngredietWithTheSameAmountOfProducts)
                {
                    if (!fullRecipes.Where(a => a.Id == recipe.RecipeId).Any())
                    {
                        fullRecipes.Add(GetRecipeById(recipe.RecipeId));
                    }
                }

                int? extractedRecipeId = null;
                foreach (var recipe in fullRecipes)
                {
                    foreach (var ingredient in recipe.Ingredients)
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
                    var dietDay = _db.Day_Recipes.FirstOrDefault(a => a.Id == recipeDayId);
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
                    var name = title + "-Copy";
                    var recipe = new Recipe { Name = name.ToString() };
                    _db.Recipes.Add(recipe);
                    _db.SaveChanges();

                    List<Recipe_Ingredients> ingredientsToAdd = new List<Recipe_Ingredients>();
                    foreach (var itm in ingredients)
                    {
                        ingredientsToAdd.Add(new Recipe_Ingredients() { ProductId = itm.Id, Amount = itm.Grams, RecipeId = recipe.Id });
                    }

                    _db.Recipe_Ingredients.AddRange(ingredientsToAdd);
                    _db.SaveChanges();

                    var dietDay = _db.Day_Recipes.FirstOrDefault(a => a.Id == recipeDayId);
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

        public IEnumerable<RecipeDTO> GetAllRecipes()
        {
            try
            {
                List<RecipeDTO> recipes = new List<RecipeDTO>();
                var result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product).ToList();

                foreach (var item in result)
                {
                    var recipe = recipes.Where(a => a.Id == item.RecipeId).FirstOrDefault();
                    if (recipe != null)
                    {
                        recipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount });
                    }
                    else
                    {
                        var newRecipe = new RecipeDTO();
                        newRecipe.Id = item.RecipeId;
                        newRecipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount });
                        newRecipe.Name = item.Recipe.Name;
                        recipes.Add(newRecipe);
                    }
                }
                return recipes;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<RecipeDTO>();
            }
        }

        //TODO Poprawić zjebaną relacją!! 
        public IEnumerable<RecipeDTO> GetByMeal(int id)
        {
            List<RecipeDTO> recipes = new List<RecipeDTO>();
            var relation = _db.MealRecipes.Where(c => c.MealsId == id).ToList();
            foreach (var item in relation)
            {
                var result = _db.Recipes.Where(a => a.Id == item.RecipesId).FirstOrDefault();
                recipes.Add(new RecipeDTO { Id = result.Id, Name = result.Name });
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

        //TODO Poprawić zjebaną relacją!! 

        public IEnumerable<RecipeDTO> GetNonDinnerRecipes()
        {
            try
            {
                var relation = _db.MealRecipes.Where(c => c.MealsId == 3).Select(a => a.RecipesId).ToList();
                var recipes = _db.Recipes
                    .Where(a => !relation.Contains(a.Id))
                    .Include(a => a.Recipe_Ingredients)
                    .ThenInclude(a => a.Product)
                    .Select(a =>
                        new RecipeDTO { Id = a.Id, Name = a.Name, Recipe_Ingredients = a.Recipe_Ingredients }
                    )
                    .ToList();
                return recipes;
            }
            catch (Exception e)
            {
                return new List<RecipeDTO>();
            }
        }

        public RecipeDTO? GetRecipeById(int? id)
        {
            if (id == null)
            {
                return new RecipeDTO();
            }
            RecipeDTO recipe = new RecipeDTO();
            var result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product).Where(a => a.RecipeId == id).ToList();

            foreach (var item in result)
            {
                recipe.Id = item.RecipeId;
                recipe.Name = item.Recipe.Name;
                recipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount });
            }
            return recipe;
        }

        public bool Remove(RecipeDTO recipe)
        {
            try
            {
                var result = _db.Recipes.Where(a => a.Id == recipe.Id).FirstOrDefault();
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
