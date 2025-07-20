using Diabetic.Models.DTOs;
using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Models.Helpers;

public static class IndexHelper
{
    public static int GetGlOnIngredient(IIngredient item)
    {
        double carbs = item.Product.CarbsPer100G * item.Amount / 100.0;
        double glycemicLoad = (item.Product.Gi * carbs) / 100.0;
        int glycemicLoadRounded = (int)Math.Floor(glycemicLoad);

        return glycemicLoadRounded;
    }

    public static int GetGlOnIngredient(Product item, int amount)
    {
        IngredientDto ingredient = new IngredientDto
        {
            Product = item,
            Amount = amount
        };
        return GetGlOnIngredient(ingredient);
    }

    public static int GetKcalsForProduct(Product item, int amount)
    {
        return (amount * (item.KcalPer100G / 100.0)).RoundToInt();
    }

    public static int GetKcalsForRecipe(RecipeDto recipe)
    {
        return recipe.Ingredients.Sum(i => GetKcalsForProduct(i.Product, (int)i.Amount));
    }
    
    public static int GetGlForRecipe(RecipeDto recipe)
    {
        return recipe.Ingredients.Sum(i => GetGlOnIngredient(i.Product, (int)i.Amount));
    }

    public static int GetGlForDay(DayDietDto dayDiet)
    {
        var totalGl = 0;
        totalGl += GetGlForRecipe(dayDiet.Breakfast);
        totalGl += GetGlForRecipe(dayDiet.Lunch);
        totalGl += GetGlForRecipe(dayDiet.Dinner);
        totalGl += GetGlForRecipe(dayDiet.Snack);
        totalGl += GetGlForRecipe(dayDiet.Supper);
        return totalGl;
    }
    
    public static int GetKcalForDay(DayDietDto dayDiet)
    {
        var totalKcal = 0;
        totalKcal += GetKcalsForRecipe(dayDiet.Breakfast);
        totalKcal += GetKcalsForRecipe(dayDiet.Lunch);
        totalKcal += GetKcalsForRecipe(dayDiet.Dinner);
        totalKcal += GetKcalsForRecipe(dayDiet.Snack);
        totalKcal += GetKcalsForRecipe(dayDiet.Supper);
        return totalKcal;
    }
    
    private static int RoundToInt(this double value)
    {
        return (int)Math.Round(value); 
    }
    
    public static int GetRemainingUserKcals(DayDietDto dayDiet, int targetKcals)
    {
        return targetKcals - GetKcalForDay(dayDiet);
    }
}