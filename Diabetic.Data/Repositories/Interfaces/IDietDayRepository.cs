using Diabetic.Models.DTOs;

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
