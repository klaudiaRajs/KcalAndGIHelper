using Diabetic.Data.Data;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var product = _db.Products.FirstOrDefault(p => p.Id == id);
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<IngredientDTO> GetAll()
        {
            try
            {
                return _db.Products.Select(product => new IngredientDTO
                {
                    Product = product 
                }).ToList();
            } catch (Exception ex)
            {
                return Enumerable.Empty<IngredientDTO>();
            }
            
        }

        public Product GetById(int id)
        {
            try
            {
                return _db.Products.Where(a => a.Id == id).FirstOrDefault(); 
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
