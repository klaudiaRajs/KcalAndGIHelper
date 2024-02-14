using Diabetic.Data.Repositories;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 

namespace Diabetic.Controllers
{
    public class DietDayController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public DietDayController(IDietDayRepository dietDayRepository, IRecipeRepository recipeRepository)
        {
            _dietDayRepository = dietDayRepository;
            this._recipeRepository = recipeRepository;
        }

        private IDietDayRepository _dietDayRepository { get; }

        public IActionResult Index()
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Days = _dietDayRepository.GetAll();
            foreach (DayDietDTO day in viewModel.Days)
            {   
                day.TotalGL = 0;
                if( day.BreakfastId != null)
                {
                    day.Breakfast = _recipeRepository.GetRecipeById((int)day.BreakfastId);
                    day.TotalGL += day.Breakfast.TotalGL;
                }
                if( day.LunchId != null)
                {
                    day.Lunch = _recipeRepository.GetRecipeById((int)day.LunchId);
                    day.TotalGL += day.Lunch.TotalGL;
                }
                if( day.DinnerId != null)
                {
                    day.Dinner = _recipeRepository.GetRecipeById((int)day.DinnerId);
                    day.TotalGL += day.Dinner.TotalGL;
                }
                if( day.SupperId != null)
                {
                    day.Supper = _recipeRepository.GetRecipeById((int)day.SupperId);
                    day.TotalGL += day.Supper.TotalGL;
                }
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.RecipesForDay = _dietDayRepository.GetDay(id);
            LoadAllRecipesForDayByDayId(id, viewModel);

            return View(viewModel);
        }

        public IActionResult Create(RecipeViewModel model)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Dinners = _recipeRepository.GetByMeal(3); 
            viewModel.Recipes = _recipeRepository.GetNonDinnerRecipes();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(DayDietViewModel model)
        {

            var result = _dietDayRepository.Create(model.RecipesForDay);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            DayDietDTO day = _dietDayRepository.GetDay(id);
            bool result = _dietDayRepository.Delete(day); 
            return RedirectToAction("Index"); 
        }

        public IActionResult GenerateShoppingList(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();     
            viewModel.RecipesForDay = _dietDayRepository.GetDay(id);
            LoadAllRecipesForDayByDayId(id, viewModel);
            List<IngredientDTO> productsToShop = ExtractIngredientsFromRecipesForDay(viewModel);

            return View("ShoppingList", productsToShop);
        }

        private List<IngredientDTO> ExtractIngredientsFromRecipesForDay(DayDietViewModel viewModel)
        {
            //Extract ingredients only from all recipes of the day
            IEnumerable<IngredientDTO> ingredients = ((viewModel.RecipesForDay.Breakfast.Ingredients)
                .Concat(viewModel.RecipesForDay.Lunch.Ingredients))
                .Concat(viewModel.RecipesForDay.Dinner.Ingredients)
                .Concat(viewModel.RecipesForDay.Supper.Ingredients);

            //Group repeated ingredients -> Collapse repeated ingredients to one ingredients and sum amount to buy
            List<IngredientDTO> distinctIngredients = ingredients
                .GroupBy(n => n.Product.Id)
                .Select(group => new IngredientDTO()
                {
                    Product = group.Select(n => n.Product).FirstOrDefault(),
                    Amount = group.Select(n => n.Amount).Sum()
                }).ToList();

            return distinctIngredients;
        }

        private void LoadAllRecipesForDayByDayId(int dayId, DayDietViewModel viewModel)
        {
            if (viewModel.RecipesForDay != null)
            {
                viewModel.RecipesForDay.Breakfast = _recipeRepository.GetRecipeById(viewModel.RecipesForDay.BreakfastId ?? 0);
                viewModel.RecipesForDay.Lunch = _recipeRepository.GetRecipeById(viewModel.RecipesForDay.LunchId ?? 0);
                viewModel.RecipesForDay.Dinner = _recipeRepository.GetRecipeById(viewModel.RecipesForDay.DinnerId ?? 0);
                viewModel.RecipesForDay.Supper = _recipeRepository.GetRecipeById(viewModel.RecipesForDay.SupperId ?? 0);
            }
        }
    }
}
