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
        List<MealDTO> GetAllByDate(string userId, DateTime? date = null);
        bool Create(Ingredient_Meal_Day ingredient_Meal_Day);
        bool InsertIngredients(List<IngredientsToMealDTO> ingredients);
        Ingredient_Meal_Day GetByProductMealAndDay(int productId, int mealId, DateTime? dateTime);
    }
}
