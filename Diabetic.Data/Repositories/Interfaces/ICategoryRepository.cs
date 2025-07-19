using Diabetic.Models;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
