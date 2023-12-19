using Diabetic.Data.Repositories;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Claims; 
using Microsoft.AspNetCore.Mvc;

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
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _viewModel.Meals = _mealRepository.GetAll();
            _viewModel.MealsWithIngredients = _dayToDayDiaryRepository.GetAllByDate(userId, selectedDate);
            return View(_viewModel);
        }

        public IActionResult AddToMeal(int mealId)
        {
            List<IngredientsToMealDTO> addToMealViewModels = new List<IngredientsToMealDTO>();
            IngredientsToMealDTO viewModel = new IngredientsToMealDTO();
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            List<IngredientsToMealDTO> ingredients = MapAddViewModelFromFormCollection(form, userId); 
            bool result = _dayToDayDiaryRepository.InsertIngredients(ingredients, dateTime);
            return RedirectToAction("Today"); 
        }

        private List<IngredientsToMealDTO> MapAddViewModelFromFormCollection(IFormCollection form, string userId)
        {
            List<IngredientsToMealDTO> ingredients = new List<IngredientsToMealDTO>();
            int numberOfLines = form.First().Value.Count - 1;
            for (int i = 0; i <= numberOfLines; i++)
            {
                ingredients.Add(new IngredientsToMealDTO());
            }

            foreach (var item in form)
            {
                
                if (nameof(IngredientsToMealDTO.SelectedMealId) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        var viewModel = ingredients.ElementAt(i);
                        viewModel.SelectedMealId = int.Parse(value);
                    }
                }
                if (nameof(IngredientsToMealDTO.Amount) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        var viewModel = ingredients.ElementAt(i);
                        viewModel.Amount = int.Parse(value);
                    }
                }
                if (nameof(IngredientsToMealDTO.SelectedProductId) == item.Key)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        string? value = item.Value[i];
                        var viewModel = ingredients.ElementAt(i);
                        viewModel.UserId = userId; 
                        viewModel.SelectedProductId = int.Parse(value);
                        var product = _productRepository.GetById(viewModel.SelectedProductId);
                        viewModel.Products.Add(new IngredientDTO { Product = product, Amount = viewModel.Amount });

                    }
                }
            }
            return ingredients; 
        }

        
        public IActionResult Remove(int productId, int mealId, string addedTo)
        {
            DateTime dateTime = DateTime.Parse(addedTo);
            Ingredient_Meal_Day record = _dayToDayDiaryRepository.GetByProductMealAndDay(productId, mealId, dateTime); 
            if (record != null)
            {
                _dayToDayDiaryRepository.Delete(record.Id); 
            }
            return RedirectToAction("Today"); 
        }

        [HttpPost]
        public IActionResult ForDate(DayToDayDiaryViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _viewModel.GetDate = model.GetDate; 
            _viewModel.Meals = _mealRepository.GetAll();
            _viewModel.MealsWithIngredients = _dayToDayDiaryRepository.GetAllByDate(userId, model.GetDate);
            return View("Today", _viewModel);
        }
    }
}
