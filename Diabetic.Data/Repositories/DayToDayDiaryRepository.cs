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

        public bool Create(IngredientMealDay ingredientMealDay)
        {
            try
            {
                Db.IngredientMealDays.Add(ingredientMealDay); 
                Db.SaveChanges();
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
                IngredientMealDay? entity = Db.IngredientMealDays.FirstOrDefault(a => a.Id == id);
                if (entity != null)
                {
                    Db.Remove(entity);
                    Db.SaveChanges();
                    return true;
                }
                return false;
            } catch( Exception ex)
            {
                return false;
            }
        }

        public List<MealDto> GetAllByDate(string userId, DateTime? date = null)
        {
            try
            {
                if(date == null)
                {
                    date = DateTime.Now.Date;
                }
                List<IngredientMealDay> ingredientsPerDate = Db.IngredientMealDays.Include(record => record.Meal).Include(record => record.Product).Where(record => record.AddedAt.Date == date.Value.Date && record.UserId == userId).ToList();
                List<MealDto> mealsWithIngredients = new List<MealDto>();
                
                foreach( IngredientMealDay ingredient in ingredientsPerDate )
                {
                    MealDto meal = new MealDto();
                    meal.Id = ingredient.Id;
                    meal.MealId = ingredient.MealId;
                    meal.Name = ingredient.Meal?.Name;
                    meal.Ingredients.Add(new IngredientDto { Product = ingredient.Product, Amount = ingredient.Amount });
                    mealsWithIngredients.Add(meal);
                }
                return mealsWithIngredients;
            } catch (Exception e) 
            { 
                return new List<MealDto>();
            }
        }

        public IngredientMealDay GetByProductMealAndDay(int productId, int mealId, DateTime? dateTime)
        {
            try
            {
                IngredientMealDay? result = Db.IngredientMealDays.FirstOrDefault(a => a.ProductId == productId && a.MealId == mealId && a.AddedAt.Date == dateTime.GetValueOrDefault().Date);
                return result; 
            } catch (Exception e)
            {
                return null; 
            }
        }

        public bool InsertIngredients(List<IngredientsToMealDto> ingredients, DateTime dateTime)
        {
            try
            {
                List<IngredientMealDay> selectedIngredients = new List<IngredientMealDay>();
                foreach (IngredientsToMealDto item in ingredients)
                {
                    IngredientMealDay ingredient = new IngredientMealDay();
                    ingredient.MealId = item.SelectedMealId;
                    ingredient.ProductId = item.SelectedProductId;
                    ingredient.AddedAt = dateTime;
                    ingredient.Amount = item.Amount;
                    ingredient.UserId = item.UserId;
                    selectedIngredients.Add(ingredient);
                }
                Db.IngredientMealDays.AddRange(selectedIngredients);
                Db.SaveChanges();

                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
