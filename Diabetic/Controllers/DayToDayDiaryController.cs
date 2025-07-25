﻿using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using System.Security.Claims; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Diabetic.Controllers
{
    public class DayToDayDiaryController : BaseController
    {
        private DayToDayDiaryViewModel _viewModel = new DayToDayDiaryViewModel();
        private readonly IMealRepository _mealRepository;
        private readonly IDayToDayDiaryRepository _dayToDayDiaryRepository;

        public DayToDayDiaryController(
            IRecipeRepository recipeRepository, 
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository, 
            IDayToDayDiaryRepository dayToDayDiaryRepository,
            IMealRepository mealRepository
        ) 
        : base(recipeRepository, productRepository, categoryRepository)
        {
            this._mealRepository = mealRepository;
            _dayToDayDiaryRepository = dayToDayDiaryRepository;
        }

        public ActionResult Today(string addedTo)
        {
            DateTime selectedDate = addedTo == null ? DateTime.Now : DateTime.Parse(addedTo); 
            
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _viewModel.Meals = _mealRepository.GetAll();
            _viewModel.MealsWithIngredients = _dayToDayDiaryRepository.GetAllByDate(userId, selectedDate);
            return View(_viewModel);
        }

        public IActionResult AddToMeal(int mealId)
        {
            List<IngredientsToMealDto> addToMealViewModels = new List<IngredientsToMealDto>();
            IngredientsToMealDto viewModel = new IngredientsToMealDto();
            viewModel.Meals = _mealRepository.GetAll();
            viewModel.Products = _productRepository.GetAll().ToList(); 
            viewModel.SelectedMealId = mealId;
            addToMealViewModels.Add(viewModel);
            return View(addToMealViewModels);
        }

        [HttpPost]
        public IActionResult AddToMeal(IFormCollection form, string addedTo)
        {
            DateTime dateTime = DateTime.Parse(addedTo);
            _viewModel.GetDate = dateTime;
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            List<IngredientsToMealDto> ingredients = MapAddViewModelFromFormCollection(form, userId); 
            bool result = _dayToDayDiaryRepository.InsertIngredients(ingredients, dateTime);
            return RedirectToAction("Today"); 
        }

        private List<IngredientsToMealDto> MapAddViewModelFromFormCollection(IFormCollection form, string userId)
        {
            List<IngredientsToMealDto> ingredients = new List<IngredientsToMealDto>();
            int numberOfLines = form.First().Value.Count - 1;
            for (int i = 0; i <= numberOfLines; i++)
            {
                ingredients.Add(new IngredientsToMealDto());
            }

            foreach (KeyValuePair<string, StringValues> item in form)
            {
                
                if (nameof(IngredientsToMealDto.SelectedMealId) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        IngredientsToMealDto viewModel = ingredients.ElementAt(i);
                        viewModel.SelectedMealId = int.Parse(value);
                    }
                }
                if (nameof(IngredientsToMealDto.Amount) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        IngredientsToMealDto viewModel = ingredients.ElementAt(i);
                        viewModel.Amount = int.Parse(value);
                    }
                }
                if (nameof(IngredientsToMealDto.SelectedProductId) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        IngredientsToMealDto viewModel = ingredients.ElementAt(i);
                        viewModel.UserId = userId; 
                        viewModel.SelectedProductId = int.Parse(value);
                        Product product = _productRepository.GetById(viewModel.SelectedProductId);
                        viewModel.Products.Add(new IngredientDto { Product = product, Amount = viewModel.Amount });

                    }
                }
            }
            return ingredients; 
        }

        
        public IActionResult Remove(int productId, int mealId, string addedTo)
        {
            DateTime dateTime = DateTime.Parse(addedTo);
            IngredientMealDay record = _dayToDayDiaryRepository.GetByProductMealAndDay(productId, mealId, dateTime); 
            if (record != null)
            {
                _dayToDayDiaryRepository.Delete(record.Id); 
            }
            return RedirectToAction("Today"); 
        }

        [HttpPost]
        public IActionResult ForDate(DayToDayDiaryViewModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _viewModel.GetDate = model.GetDate; 
            _viewModel.Meals = _mealRepository.GetAll();
            _viewModel.MealsWithIngredients = _dayToDayDiaryRepository.GetAllByDate(userId, model.GetDate);
            return View("Today", _viewModel);
        }
    }
}
