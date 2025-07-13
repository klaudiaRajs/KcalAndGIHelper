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

        public IEnumerable<DayDietDto> GetAll()
        {
            try
            {
                List<DayDietDto> days = Db.DayRecipes.Select(a => new DayDietDto
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
                DayDietDto? day = Db.DayRecipes.Where(a => a.Id == id).Select(a => new DayDietDto
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
                DayRecipe entity = new DayRecipe();
                entity.BreakfastRecipeId = day.BreakfastId;
                entity.LunchRecipeId = day.LunchId;
                entity.DinnerRecipeId = day.DinnerId;
                entity.SnackRecipeId = day.SnackId;
                entity.SupperRecipeId = day.SupperId;

                Db.DayRecipes.Add(entity);
                Db.SaveChanges();
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
                DayRecipe dayRecipe = Db.DayRecipes.FirstOrDefault(a => a.Id == day.Id);
                Db.Remove(dayRecipe);
                Db.SaveChanges();
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
                DayRecipe dayRecipe = Db.DayRecipes.FirstOrDefault(a => a.Id == id);
                dayRecipe.BreakfastRecipeId = day.BreakfastId;
                dayRecipe.LunchRecipeId = day.LunchId; 
                dayRecipe.DinnerRecipeId = day.DinnerId;
                dayRecipe.SnackRecipeId = day.SnackId;
                dayRecipe.SupperRecipeId = day.SupperId;
                Db.Update(dayRecipe);
                Db.SaveChanges();
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
