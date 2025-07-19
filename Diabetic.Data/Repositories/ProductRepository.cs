using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;

namespace Diabetic.Data.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }

        public bool Create(Product product)
        {
            try
            {
                product.Name = product.Name.ToLower();
                _db.Products.Add(product);
                _db.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false; 
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Product? product = _db.Products.FirstOrDefault(p => p.Id == id);
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<IngredientDto> GetAll()
        {
            try
            {
                return _db.Products.Select(product => new IngredientDto
                {
                    Product = product 
                }).ToList();
            } catch (Exception ex)
            {
                return Enumerable.Empty<IngredientDto>();
            }
            
        }

        public Product GetById(int id)
        {
            try
            {
                return _db.Products.FirstOrDefault(a => a.Id == id); 
            } catch(Exception ex)
            {
                //Add logging 
                return new Product(); 

            }
        }

        public bool Update(Product product)
        {
            try
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}
