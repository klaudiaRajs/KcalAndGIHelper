using Diabetic.Data.Repositories;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    public class DayToDayDiaryController : Controller
    {
        private DayToDayDiaryViewModel _viewModel = new DayToDayDiaryViewModel();
        private readonly IMealRepository _mealRepository;
        private readonly IDayToDayDiaryRepository _dayToDayDiaryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DayToDayDiaryController(IMealRepository mealRepository, IDayToDayDiaryRepository dayToDayDiaryRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._mealRepository = mealRepository;
            _dayToDayDiaryRepository = dayToDayDiaryRepository;
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }
        public ActionResult Today()
        {
            _viewModel.Meals = _mealRepository.GetAll();
            _viewModel.MealsWithIngredients = _dayToDayDiaryRepository.GetAllByDate();
            return View(_viewModel);
        }

        public IActionResult Remove(int id)
        {
            bool result = _dayToDayDiaryRepository.Delete(id);
            return RedirectToAction("Today");
        }

        public IActionResult AddToMeal(int mealId)
        {
            AddToMealViewModel viewModel = new AddToMealViewModel();
            viewModel.Meals = _mealRepository.GetAll();
            viewModel.Products = _productRepository.GetAll(); 
            viewModel.SelectedMealId = mealId;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToMeal(AddToMealViewModel model)
        {
            var entity = new Ingredient_Meal_Day { AddedAt = DateTime.Now, Amount = model.Amount, MealId = model.SelectedMealId, ProductId = model.SelectedProductId };
            _dayToDayDiaryRepository.Create(entity);
            return RedirectToAction("Today"); 
        }
    }
}
