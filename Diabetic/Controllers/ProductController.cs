﻿using Diabetic.Data.Repositories.Interfaces;
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
        private ProductViewModel ProductViewModel { get; set; } = new ProductViewModel();
        private readonly ICategoryRepository _categoryRepository; 

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            ProductViewModel.Categories = _categoryRepository.GetAll();
            ProductViewModel.Products = _productRepository.GetAll();
        }
        public IActionResult Index()
        {
            return View(ProductViewModel);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel productViewModel)
        {
            IEnumerable<IngredientDto> products = _productRepository.GetAll(); 
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
                products = products.Where(a => a.Product.KcalPer100G >= productViewModel.CaloryRangeMin); 
            }
            if (productViewModel.CaloryRangeMax != 0)
            {
                products = products.Where(a => a.Product.KcalPer100G <= productViewModel.CaloryRangeMax);
            }
            if(productViewModel.Green == true && productViewModel.Orange == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.Gi <= productViewModel.MaxGreen || a.Product.Gi > productViewModel.MaxGreen && a.Product.Gi <= productViewModel.MaxOrange || a.Product.Gi > productViewModel.MaxOrange); 
            } 
            else if (productViewModel.Green == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.Gi <= productViewModel.MaxGreen || a.Product.Gi > productViewModel.MaxGreen && a.Product.Gi <= productViewModel.MaxOrange);
            }
            else if (productViewModel.Green == true && productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.Gi <= productViewModel.MaxGreen || a.Product.Gi > productViewModel.MaxOrange);
            }
            else if (productViewModel.Red == true && productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.Gi > productViewModel.MaxGreen && a.Product.Gi <= productViewModel.MaxOrange || a.Product.Gi > productViewModel.MaxOrange);
            }
            else if (productViewModel.Green == true)
            {
                products = products.Where(a => a.Product.Gi <= productViewModel.MaxGreen);
            }
            else if(productViewModel.Orange == true)
            {
                products = products.Where(a => a.Product.Gi <= productViewModel.MaxOrange || a.Product.Gi > productViewModel.MaxOrange);
            }
            else if( productViewModel.Red == true)
            {
                products = products.Where(a => a.Product.Gi > productViewModel.MaxOrange);
            }

            ProductViewModel.Products = products.ToList();
            return View(ProductViewModel);
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
            Product product = productViewModel.Product;
            bool result = _productRepository.Create(product); 
            SeederService.GenerateSeederForProductCreate(product);
            return RedirectToAction("Index"); 
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            Product product = _productRepository.GetById(id); 
            ProductViewModel.Product = product;
            return View("Create", ProductViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Details(ProductViewModel model)
        {
            Product product = model.Product;
            bool result = _productRepository.Update(product);
            SeederService.GenerateSeederForProductCreate(product);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            bool result = _productRepository.Delete(id);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Products(string prefix)
        {
            List<IngredientDto> products = _productRepository.GetAll().Where(a => a.ProductName.StartsWith(prefix)).ToList();
            return Json(products);
        }
    }
}
