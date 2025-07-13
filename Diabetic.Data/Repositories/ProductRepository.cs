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
                product.Name = product.Name.ToLower();
                Db.Products.Add(product);
                Db.SaveChanges();
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
                Product? product = Db.Products.FirstOrDefault(p => p.Id == id);
                Db.Products.Remove(product);
                Db.SaveChanges();
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
                return Db.Products.Select(product => new IngredientDto
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
                return Db.Products.FirstOrDefault(a => a.Id == id); 
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
                Db.Products.Update(product);
                Db.SaveChanges();
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}
