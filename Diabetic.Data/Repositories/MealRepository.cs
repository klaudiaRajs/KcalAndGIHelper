using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;

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
                return _db.Meals.ToList(); 
            } catch (Exception ex)
            {
                //TODO add logging 
                return new List<Meal>();
            }
        }
    }
}
