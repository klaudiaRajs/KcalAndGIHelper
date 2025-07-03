using Diabetic.Models;

namespace Diabetic.Services;

public class GlicemicIndexHelper
{
    public static int GetGlOnIngredient(Recipe_Ingredients item)
    {
        return (int)Math.Floor((item.Product.GI * item.Product.CarbsPer100g) / 100); 
    }
}