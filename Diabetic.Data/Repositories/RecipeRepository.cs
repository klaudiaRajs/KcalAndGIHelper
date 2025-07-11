﻿using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diabetic.Services;
using Microsoft.VisualBasic.CompilerServices;

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
                List<int> products = ingredients.Select(a => a.Id).ToList();
                List<int> grams = ingredients.Select(a => a.Grams).ToList();

                var recipeIdsWithTheSameAmountOfProducts = _db.Recipe_Ingredients.GroupBy(a => a.RecipeId, (a, b) => new { RecipeId = a, NumberOfProducts = b.Count() }).Where(x => x.NumberOfProducts == products.Count() && x.RecipeId != recipeDayId).ToList();

                List<int> newRecipeIdsWithTheSameAmountOfProducts = recipeIdsWithTheSameAmountOfProducts.Select(a => a.RecipeId).ToList();

                List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Where(a => products.Contains(a.ProductId) && grams.Contains(a.Amount) && a.RecipeId != recipeId).ToList();

                List<Recipe_Ingredients> recipeIngredietWithTheSameAmountOfProducts = _db.Recipe_Ingredients.Where(a => newRecipeIdsWithTheSameAmountOfProducts.Contains(a.RecipeId)).ToList();

                List<RecipeDTO> fullRecipes = new List<RecipeDTO>();
                foreach (Recipe_Ingredients recipe in recipeIngredietWithTheSameAmountOfProducts)
                {
                    if (!fullRecipes.Where(a => a.Id == recipe.RecipeId).Any())
                    {
                        fullRecipes.Add(GetRecipeById(recipe.RecipeId));
                    }
                }

                int? extractedRecipeId = null;
                foreach (RecipeDTO recipe in fullRecipes)
                {
                    foreach (IngredientDTO ingredient in recipe.Ingredients)
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
                    foreach (SelectionDTO itm in ingredients)
                    {
                        ingredientsToAdd.Add(new Recipe_Ingredients() { ProductId = itm.Id, Amount = itm.Grams, RecipeId = recipe.Id });
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

        public IEnumerable<RecipeDTO> GetAllRecipes()
        {
            try
            {
                List<RecipeDTO> recipes = new List<RecipeDTO>();
                List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product).ToList();

                foreach (Recipe_Ingredients item in result)
                {
                    RecipeDTO? recipe = recipes.FirstOrDefault(a => a.Id == item.RecipeId);
                    if (recipe != null)
                    {
                        recipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item) });
                    }
                    else
                    {
                        RecipeDTO newRecipe = new RecipeDTO();
                        newRecipe.Id = item.RecipeId;
                        newRecipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item)  });
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
            List<MealRecipe> relation = _db.MealRecipes.Where(c => c.MealsId == id).ToList();
            foreach (MealRecipe item in relation)
            {
                Recipe? result = _db.Recipes.FirstOrDefault(a => a.Id == item.RecipesId);
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
                List<int> relation = _db.MealRecipes.Where(c => c.MealsId == 3).Select(a => a.RecipesId).ToList();
                List<RecipeDTO> recipes = _db.Recipes
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

        public RecipeDTO GetRecipeById(int? id)
        {
            if (id == null)
            {
                return new RecipeDTO();
            }
            RecipeDTO recipe = new RecipeDTO();
            List<Recipe_Ingredients> result = _db.Recipe_Ingredients.Include(a => a.Recipe).Include(a => a.Product).Where(a => a.RecipeId == id).ToList();

            foreach (Recipe_Ingredients item in result)
            {
                recipe.Id = item.RecipeId;
                recipe.Name = item.Recipe.Name;
                recipe.Ingredients.Add(new IngredientDTO { Product = item.Product, Amount = item.Amount, Gl = IndexHelper.GetGlOnIngredient(item) });
            }
            return recipe;
        }

        public bool Remove(RecipeDTO recipe)
        {
            try
            {
                Recipe? result = _db.Recipes.FirstOrDefault(a => a.Id == recipe.Id);
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
