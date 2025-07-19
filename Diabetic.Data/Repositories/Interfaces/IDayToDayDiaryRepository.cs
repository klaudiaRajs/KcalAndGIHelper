using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IDayToDayDiaryRepository
    {
        bool Delete(int id);
        List<MealDto> GetAllByDate(string userId, DateTime? date = null);
        bool Create(IngredientMealDay ingredientMealDay);
        bool InsertIngredients(List<IngredientsToMealDto> ingredients, DateTime dateTime);
        IngredientMealDay GetByProductMealAndDay(int productId, int mealId, DateTime? dateTime);
    }
}
