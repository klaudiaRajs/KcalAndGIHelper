using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IngredientDto> GetAll();
        bool Create(Product product);
        Product GetById(int id);
        bool Update(Product product);
        bool Delete(int id);
    }
}
