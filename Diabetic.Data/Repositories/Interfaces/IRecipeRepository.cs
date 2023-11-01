﻿using Diabetic.Models;
using Diabetic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        RecipeDTO GetRecipeById(int id);
        IEnumerable<Recipe> GetAllRecipes();
        IEnumerable<RecipeDTO> GetByMeal(int id);
        IEnumerable<RecipeDTO> GetNonDinnerRecipes();
        bool Create(Recipe recipe);
        bool AddIngredientsToRecipe(Recipe newRecipe, List<Recipe_Ingredients> ingredients);
        bool Remove(RecipeDTO recipe);
        List<Recipe_Ingredients> GetIngredientsByRecipe(int id);
        bool RemoveIngredientsForRecipe(List<Recipe_Ingredients> ingredients);
        bool Update(Recipe recipe);
        bool UpdateIngredientsForRecipe(Recipe currentRecipe, List<Recipe_Ingredients> toBeUpdated);
    }
}
