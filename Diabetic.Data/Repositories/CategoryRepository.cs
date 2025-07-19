using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;

namespace Diabetic.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
