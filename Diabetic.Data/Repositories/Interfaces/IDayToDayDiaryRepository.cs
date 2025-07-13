using Diabetic.Models;
using Diabetic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
