using Diabetic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IDietDayRepository
    {
        DayDietDto GetDay(int id); 
        IEnumerable<DayDietDto> GetAll();
        bool Create(DayDietDto day);
        bool Update(DayDietDto day, int id);
        bool Delete(DayDietDto day);
    }
}
