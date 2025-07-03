using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Services;

public static class GlicemicIndexHelper
{
    public static int GetGlOnIngredient(IIngredient item)
    {
        double carbs = item.Product.CarbsPer100g * item.Amount / 100.0;
        double glycemicLoad = (item.Product.Gi * carbs) / 100.0;
        int glycemicLoadRounded = (int)Math.Floor(glycemicLoad);

        return glycemicLoadRounded; 
    }
}