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
        DayDietDTO GetDay(int id); 
        IEnumerable<DayDietDTO> GetAll();
        bool Create(DayDietDTO day);
        bool Delete(DayDietDTO day);
    }
}
