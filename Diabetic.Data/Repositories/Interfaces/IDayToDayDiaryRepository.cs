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
        List<MealDTO> GetAllByDate(DateTime? date = null);
        bool Create(Ingredient_Meal_Day ingredient_Meal_Day); 
    }
}
