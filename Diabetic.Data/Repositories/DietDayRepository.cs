﻿using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories
{
    public class DietDayRepository : BaseRepository, IDietDayRepository
    {
        public DietDayRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<DayDietDto> GetAll()
        {
            try
            {
                List<DayDietDto> days = _db.Day_Recipes.Select(a => new DayDietDto
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
                return new List<DayDietDto>(); 
            }
        }

        public DayDietDto GetDay(int id)
        {
            try
            {
                DayDietDto? day = _db.Day_Recipes.Where(a => a.Id == id).Select(a => new DayDietDto
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

        public bool Create(DayDietDto day)
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

        public bool Delete(DayDietDto day)
        {
            try
            {
                Day_Recipe dayRecipe = _db.Day_Recipes.FirstOrDefault(a => a.Id == day.Id);
                _db.Remove(dayRecipe);
                _db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                //TODO logowanie do pliku 
                return false;
            }


        }

        public bool Update(DayDietDto day, int id)
        {
            try
            {
                Day_Recipe dayRecipe = _db.Day_Recipes.FirstOrDefault(a => a.Id == id);
                dayRecipe.BreakfastRecipeId = day.BreakfastId;
                dayRecipe.LunchRecipeId = day.LunchId; 
                dayRecipe.DinnerRecipeId = day.DinnerId;
                dayRecipe.SnackRecipeId = day.SnackId;
                dayRecipe.SupperRecipeId = day.SupperId;
                _db.Update(dayRecipe);
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
