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
        double carbs = item.CarbsPer100G * amount / 100.0;
        double glycemicLoad = (item.Gi * carbs) / 100.0;
        int glycemicLoadRounded = (int)Math.Floor(glycemicLoad);

        return glycemicLoadRounded;
    }

    public static int GetKcalsForProduct(Product item, int amount)
    {
        return amount * (item.KcalPer100G / 100);
    }

    public static int GetKcalsForRecipe(RecipeDto recipe)
    {
        return recipe.Ingredients.Sum(i => GetKcalsForProduct(i.Product, (int)i.Amount));
    }
    
    public static int GetGlForRecipe(RecipeDto recipe)
    {
        return recipe.Ingredients.Sum(i => GetGlOnIngredient(i.Product, (int)i.Amount));
    }
}