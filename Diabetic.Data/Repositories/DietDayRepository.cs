using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
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
        }

        public DayDietDTO GetDay(int id)
        {
            var day = _db.Day_Recipes.Where(a => a.DayId == id).Select(a => new DayDietDTO
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
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
