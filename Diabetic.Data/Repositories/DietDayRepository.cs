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
    public class DietDayRepository : BaseRepository, IDietDayRepository
    {
        public DietDayRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<DayDietDTO> GetAll()
        {
            try
            {
                var days = _db.Day_Recipes.Select(a => new DayDietDTO
                {
                    Id = a.Id,
                    BreakfastId = a.BreakfastRecipeId,
                    LunchId = a.LunchRecipeId,
                    DinnerId = a.DinnerRecipeId,
                    SnackId = a.SnackRecipeId,
                    SupperId = a.SupperRecipeId
                }).ToList();

                return days;
            } catch(Exception ex)
            {
                //TODO zrób logowanie do pliku 
                return new List<DayDietDTO>(); 
            }
        }

        public DayDietDTO GetDay(int id)
        {
            try
            {
                var day = _db.Day_Recipes.Where(a => a.Id == id).Select(a => new DayDietDTO
                {
                    Id = a.Id,
                    BreakfastId = a.BreakfastRecipeId,
                    LunchId = a.LunchRecipeId,
                    DinnerId = a.DinnerRecipeId,
                    SnackId = a.SnackRecipeId,
                    SupperId = a.SupperRecipeId
                }).FirstOrDefault();

                return day;
            }
            catch (Exception ex)
            {
                //TODO logowanie do pliku 
                return null;
            }
        }

        public bool Create(DayDietDTO day)
        {
            try
            {
                Day_Recipe entity = new Day_Recipe();
                entity.BreakfastRecipeId = day.BreakfastId;
                entity.LunchRecipeId = day.LunchId;
                entity.DinnerRecipeId = day.DinnerId;
                entity.SnackRecipeId = day.SnackId;
                entity.SupperRecipeId = day.SupperId;

                _db.Day_Recipes.Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //TODO logowanie do pliku 
                return false;
            }
        }

        public bool Delete(DayDietDTO day)
        {
            try
            {
                Day_Recipe day_Recipe = _db.Day_Recipes.Where(a => a.Id == day.Id).FirstOrDefault();
                _db.Remove(day_Recipe);
                _db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                //TODO logowanie do pliku 
                return false;
            }


        }

        public bool Update(DayDietDTO day, int id)
        {
            try
            {
                Day_Recipe day_Recipe = _db.Day_Recipes.Where(a => a.Id == id).FirstOrDefault();
                day_Recipe.BreakfastRecipeId = day.BreakfastId;
                day_Recipe.LunchRecipeId = day.LunchId; 
                day_Recipe.DinnerRecipeId = day.DinnerId;
                day_Recipe.SnackRecipeId = day.SnackId;
                day_Recipe.SupperRecipeId = day.SupperId;
                _db.Update(day_Recipe);
                _db.SaveChanges();
                return true; 
            }
            catch(Exception e)
            {
                //TODO logowanie do pliku 
                return false; 
            }
        }
    }
}
