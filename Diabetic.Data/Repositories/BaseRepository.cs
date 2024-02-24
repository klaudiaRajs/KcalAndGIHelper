using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
