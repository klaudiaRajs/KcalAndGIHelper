using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Diabetic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<IngredientDTO> products = _productRepository.GetAll(); 
            if (productViewModel.Product.Name != null)
            {
                products = products.Where(a => a.Product.Name.Contains(productViewModel.Product.Name));
            }
            if( productViewModel.Product.CategoryId != 0)
            {
                products = products.Where(a => a.Product.CategoryId == productViewModel.Product.CategoryId);
            }
            if (productViewModel.CaloryRangeMin != 0)
            {
                products = products.Where(a => a.Product.KcalPer100g >= productViewModel.CaloryRangeMin); 
            }
            if (productViewModel.CaloryRangeMax != 0)
            {
                products = products.Where(a => a.Product.KcalPer100g <= productViewModel.CaloryRangeMax);
            }
            if(productViewModel.Green == true && productViewModel.Orange == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.GI <= productViewModel._maxGreen || a.Product.GI > productViewModel._maxGreen && a.Product.GI <= productViewModel._maxOrange || a.Product.GI > productViewModel._maxOrange); 
            } 
            else if (productViewModel.Green == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.GI <= productViewModel._maxGreen || a.Product.GI > productViewModel._maxGreen && a.Product.GI <= productViewModel._maxOrange);
            }
            else if (productViewModel.Green == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.GI <= productViewModel._maxGreen || a.Product.GI > productViewModel._maxOrange);
            }
            else if (productViewModel.Red == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.GI > productViewModel._maxGreen && a.Product.GI <= productViewModel._maxOrange || a.Product.GI > productViewModel._maxOrange);
            }
            else if (productViewModel.Green == true)
            {
                products = products.Where(a => a.Product.GI <= productViewModel._maxGreen);
            }
            else if(productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.GI <= productViewModel._maxOrange || a.Product.GI > productViewModel._maxOrange);
            }
            else if( productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.GI > productViewModel._maxOrange);
            }

            _productViewModel.Products = products.ToList();
            return View(_productViewModel);
        }
        [Authorize]
        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel(); 
            model.Categories = _categoryRepository.GetAll();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;
            var result = _productRepository.Create(product); 
            SeederService.GenerateSeederForProductCreate(product);
            return RedirectToAction("Index"); 
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetById(id); 
            _productViewModel.Product = product;
            return View("Create", _productViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(ProductViewModel model)
        {
            var product = model.Product;
            var result = _productRepository.Update(product);
            SeederService.GenerateSeederForProductCreate(product);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var result = _productRepository.Delete(id);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Products(string prefix)
        {
            var products = _productRepository.GetAll().Where(a => a.ProductName.StartsWith(prefix)).ToList();
            return Json(products);
        }
    }
}
