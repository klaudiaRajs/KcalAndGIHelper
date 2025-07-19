using Diabetic.Data.Repositories.Interfaces;

namespace Diabetic.Data.Repositories
{
    public class BaseRepository
    {
        

        protected ApplicationDbContext _db;
        private IDietDayRepository _repository;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
