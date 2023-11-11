using Diabetic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        bool Create(Product product);
        Product GetById(int id);
        bool Update(Product product);
    }
}
