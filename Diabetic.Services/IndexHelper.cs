using Diabetic.Models;
using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Services;

public static class IndexHelper
{
    public static int GetGlOnIngredient(IIngredient item)
    {
        double carbs = item.Product.CarbsPer100g * item.Amount / 100.0;
        double glycemicLoad = (item.Product.Gi * carbs) / 100.0;
        int glycemicLoadRounded = (int)Math.Floor(glycemicLoad);

        return glycemicLoadRounded; 
    }
    
    public static int GetGlOnIngredient(Product item, int amount)
    {
        double carbs = item.CarbsPer100g * amount / 100.0;
        double glycemicLoad = (item.Gi * carbs) / 100.0;
        int glycemicLoadRounded = (int)Math.Floor(glycemicLoad);

        return glycemicLoadRounded; 
    }
    
    public static int GetKcalsForProduct(Product item, int amount)
    {
        return amount * (item.KcalPer100g / 100); 
    }
}