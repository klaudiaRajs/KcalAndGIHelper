using Diabetic.Data.Data;
using Diabetic.Data.Repositories;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diabetic.Controllers
{
    public class ProductController : Controller 
    {
        private readonly IProductRepository _productRepository;
        private ProductViewModel _productViewModel { get; set; } = new ProductViewModel();
        private readonly ICategoryRepository _categoryRepository; 

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productViewModel.Categories = _categoryRepository.GetAll();
            _productViewModel.Products = _productRepository.GetAll();
        }
        public IActionResult Index()
        {
            return View(_productViewModel);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel productViewModel)
        {
            IEnumerable<Product> products = _productRepository.GetAll(); 
            if (productViewModel.Product.Name != null)
            {
                products = products.Where(a => a.Name.Contains(productViewModel.Product.Name));
            }
            if( productViewModel.Product.CategoryId != 0)
            {
                products = products.Where(a => a.CategoryId == productViewModel.Product.CategoryId);
            }
            if (productViewModel.CaloryRangeMin != 0)
            {
                products = products.Where(a => a.KcalPer100g >= productViewModel.CaloryRangeMin); 
            }
            if (productViewModel.CaloryRangeMax != 0)
            {
                products = products.Where(a => a.KcalPer100g <= productViewModel.CaloryRangeMax);
            }
            if(productViewModel.Green == true && productViewModel.Orange == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.GI <= productViewModel._maxGreen || a.GI > productViewModel._maxGreen && a.GI <= productViewModel._maxOrange || a.GI > productViewModel._maxOrange); 
            } 
            else if (productViewModel.Green == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.GI <= productViewModel._maxGreen || a.GI > productViewModel._maxGreen && a.GI <= productViewModel._maxOrange);
            }
            else if (productViewModel.Green == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.GI <= productViewModel._maxGreen || a.GI > productViewModel._maxOrange);
            }
            else if (productViewModel.Red == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.GI > productViewModel._maxGreen && a.GI <= productViewModel._maxOrange || a.GI > productViewModel._maxOrange);
            }
            else if (productViewModel.Green == true)
            {
                products = products.Where(a => a.GI <= productViewModel._maxGreen);
            }
            else if(productViewModel.Orange == true)
            {
                products = products.Where(a => a.GI <= productViewModel._maxOrange || a.GI > productViewModel._maxOrange);
            }
            else if( productViewModel.Red == true)
            {
                products = products.Where(a => a.GI > productViewModel._maxOrange);
            }

            _productViewModel.Products = products.ToList();
            return View(_productViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;
            var result = _productRepository.Create(product); 
            SeederService.GenerateSeederForProductCreate(product);
            return RedirectToAction("Index"); 
        }
    }
}
