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
                Ingredient_Meal_Day? entity = _db.Ingredient_Meal_Days.FirstOrDefault(a => a.Id == id);
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

        public List<MealDTO> GetAllByDate(string userId, DateTime? date = null)
        {
            try
            {
                if(date == null)
                {
                    date = DateTime.Now.Date;
                }
                List<Ingredient_Meal_Day> ingredientsPerDate = _db.Ingredient_Meal_Days.Include(record => record.Meal).Include(record => record.Product).Where(record => record.AddedAt.Date == date.Value.Date && record.UserId == userId).ToList();
                List<MealDTO> mealsWithIngredients = new List<MealDTO>();
                
                foreach( Ingredient_Meal_Day ingredient in ingredientsPerDate )
                {
                    MealDTO meal = new MealDTO();
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

        public Ingredient_Meal_Day GetByProductMealAndDay(int productId, int mealId, DateTime? dateTime)
        {
            try
            {
                Ingredient_Meal_Day? result = _db.Ingredient_Meal_Days.FirstOrDefault(a => a.ProductId == productId && a.MealId == mealId && a.AddedAt.Date == dateTime.GetValueOrDefault().Date);
                return result; 
            } catch (Exception e)
            {
                return null; 
            }
        }

        public bool InsertIngredients(List<IngredientsToMealDTO> ingredients, DateTime dateTime)
        {
            try
            {
                List<Ingredient_Meal_Day> selectedIngredients = new List<Ingredient_Meal_Day>();
                foreach (IngredientsToMealDTO item in ingredients)
                {
                    Ingredient_Meal_Day ingredient = new Ingredient_Meal_Day();
                    ingredient.MealId = item.SelectedMealId;
                    ingredient.ProductId = item.SelectedProductId;
                    ingredient.AddedAt = dateTime;
                    ingredient.Amount = item.Amount;
                    ingredient.UserId = item.UserId;
                    selectedIngredients.Add(ingredient);
                }
                _db.Ingredient_Meal_Days.AddRange(selectedIngredients);
                _db.SaveChanges();

                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
