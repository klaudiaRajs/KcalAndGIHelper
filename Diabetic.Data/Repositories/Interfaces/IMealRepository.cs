using Diabetic.Models;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IMealRepository
    {
        IEnumerable<Meal> GetAll(); 
    }
}
