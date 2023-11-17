using Diabetic.Models;
using Diabetic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IngredientDTO> GetAll();
        bool Create(Product product);
        Product GetById(int id);
        bool Update(Product product);
        bool Delete(int id);
    }
}
