using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories
{
    public class DayToDayDiaryRepository : BaseRepository, IDayToDayDiaryRepository
    {
        public DayToDayDiaryRepository(ApplicationDbContext db) : base(db)
        {
        }

        public bool Create(Ingredient_Meal_Day ingredient_Meal_Day)
        {
            try
            {
                _db.Ingredient_Meal_Days.Add(ingredient_Meal_Day); 
                _db.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _db.Ingredient_Meal_Days.Where(a => a.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    _db.Remove(entity);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            } catch( Exception ex)
            {
                return false;
            }
        }

        public List<MealDTO> GetAllByDate(DateTime? date = null)
        {
            try
            {
                if(date == null)
                {
                    date = DateTime.Now.Date;
                }
                var ingredientsPerDate = _db.Ingredient_Meal_Days.Include(record => record.Meal).Include(record => record.Product).Where(record => record.AddedAt.Date == date).ToList();
                List<MealDTO> mealsWithIngredients = new List<MealDTO>();
                
                foreach( var ingredient in ingredientsPerDate )
                {
                    var meal = new MealDTO();
                    meal.Id = ingredient.Id;
                    meal.MealId = ingredient.MealId;
                    meal.Name = ingredient.Meal?.Name;
                    meal.Ingredients.Add(new IngredientDTO { Product = ingredient.Product, Amount = ingredient.Amount });
                    mealsWithIngredients.Add(meal);
                }
                return mealsWithIngredients;
            } catch (Exception e) 
            { 
                return new List<MealDTO>();
            }
        }
    }
}
