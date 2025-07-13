using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories
{
    public class MealRepository : BaseRepository, IMealRepository
    {
        public MealRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Meal> GetAll()
        {
            try
            {
                return Db.Meals.ToList(); 
            } catch (Exception ex)
            {
                //TODO add logging 
                return new List<Meal>();
            }
        }
    }
}
