using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Diabetic.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    public class DietDayController : BaseController
    {
        private IDietDayRepository _dietDayRepository { get; }
        public DietDayController(
            IRecipeRepository recipeRepository, 
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository, 
            IDietDayRepository dietDayRepository, 
            IMealRepository? mealRepository = null) 
            : base(recipeRepository, productRepository, categoryRepository, mealRepository)
        {
            _dietDayRepository = dietDayRepository;
            
        }

        public IActionResult Index()
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Days = _dietDayRepository.GetAll();
            foreach (DayDietDto day in viewModel.Days)
            {
                //TODO Refactor 
                day.Breakfast = _recipeRepository.GetRecipeById(day.BreakfastId);
                day.Lunch = _recipeRepository.GetRecipeById(day.LunchId);
                day.Dinner = _recipeRepository.GetRecipeById(day.DinnerId);
                day.Supper = _recipeRepository.GetRecipeById(day.SupperId);
                day.Snack = _recipeRepository.GetRecipeById(day.SnackId);
                day.SetTotalGl();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(DayDietViewModel model) => GenerateShoppingListForMultipleDays(model.SelectedDaysIds);
        
        public IActionResult Details(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.RecipesForDay = _dietDayRepository.GetDay(id);

            LoadAllRecipesForDayByDayId(viewModel.RecipesForDay);
            viewModel.SetTotalKcals(); 
            viewModel.SetTotalGl();
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
            bool result = _dietDayRepository.Create(model.RecipesForDay);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            DayDietDto day = _dietDayRepository.GetDay(id);
            bool result = _dietDayRepository.Delete(day);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            DayDietDto day = _dietDayRepository.GetDay(id);
            DayDietViewModel model = new DayDietViewModel { RecipesForDay = day, Id = day.Id };
            if (model.RecipesForDay != null)
            {
                LoadAllRecipesForDayByDayId(model.RecipesForDay);
                model.SelectedKcals = model.SetTotalKcals();
                model.SelectedGl = model.SetTotalGl();
            }

            model.Dinners = _recipeRepository.GetByMeal(3);
            model.Recipes = _recipeRepository.GetNonDinnerRecipes();

            return View("Create", model);
        }
        //Make it async 
        public IActionResult UpdateDay(int recipeId, string meal, int dayId)
        {
            DayDietDto day = _dietDayRepository.GetDay(dayId);
            day = UpdateRecipes(meal, day, recipeId);
            LoadAllRecipesForDayByDayId(day);
            _dietDayRepository.Update(day, dayId);
            return Ok(new { success = true, totalKcal = IndexHelper.GetKcalForDay(day), totalGl = IndexHelper.GetGlForDay(day) }); 
        }

        private DayDietDto UpdateRecipes(string meal, DayDietDto day, int recipeId)
        {
            switch (meal)
            {
                case "dinner":
                    day.DinnerId = recipeId;
                    break; 
                case "breakfast":
                    day.BreakfastId = recipeId;
                    break;
                case "lunch":
                    day.LunchId = recipeId;
                    break;
                case "supper":
                    day.SupperId = recipeId;
                    break;
                case "snack":
                    day.SnackId = recipeId;
                    break;
            }

            return day; 
        }
        
        public IActionResult GenerateShoppingListForMultipleDays(List<int> daysIds)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            List<IngredientDto> productsToShop = new List<IngredientDto>();
            foreach (int dayId in daysIds)
            {
                viewModel.RecipesForDay = _dietDayRepository.GetDay(dayId);
                LoadAllRecipesForDayByDayId(viewModel.RecipesForDay);
                productsToShop.AddRange(ExtractIngredientsFromRecipesForDay(viewModel));
            }
            productsToShop = CollapseRepeatedIngredients(productsToShop);
            //Sort alphabetically
            productsToShop = productsToShop.OrderBy(n => n.Product.Name).ToList();
            
            return View("ShoppingList", productsToShop);
        }
        
        public IActionResult GenerateShoppingListForOneDay(int id)
        {
            return RedirectToAction(nameof(GenerateShoppingListForMultipleDays), new { daysIds = new List<int> { id } });
        }

        private List<IngredientDto> ExtractIngredientsFromRecipesForDay(DayDietViewModel viewModel)
        {
            //Extract IngredientDTO only from all recipes of the day and merge them into list
            return (((viewModel.RecipesForDay.Breakfast.Ingredients)
                .Concat(viewModel.RecipesForDay.Lunch.Ingredients))
                .Concat(viewModel.RecipesForDay.Dinner.Ingredients)
                .Concat(viewModel.RecipesForDay.Supper.Ingredients)).ToList();
        }

        private List<IngredientDto> CollapseRepeatedIngredients(List<IngredientDto> ingredients)
        {
            //Group repeated ingredients, then collapse repeated ingredients to one ingredient and sum amount to buy.
            return ingredients
                .GroupBy(n => n.Product.Id)           
                .Select(group => new IngredientDto()
                {
                    Product = group.Select(n => n.Product).FirstOrDefault(),
                    Amount = group.Select(n => n.Amount).Sum()
                })
                .ToList();
        }

        private void LoadAllRecipesForDayByDayId(DayDietDto viewModel)
        {
            if (viewModel != null)
            {
                viewModel.Breakfast = _recipeRepository?.GetRecipeById(viewModel.BreakfastId ?? 0) ?? new RecipeDto();
                viewModel.Breakfast.MealId = 1;
                viewModel.Breakfast.RecipeDayId = viewModel.Id; 

                viewModel.Lunch = _recipeRepository?.GetRecipeById(viewModel.LunchId ?? 0) ?? new RecipeDto();
                viewModel.Lunch.MealId = 2;
                viewModel.Lunch.RecipeDayId = viewModel.Id;

                viewModel.Dinner = _recipeRepository?.GetRecipeById(viewModel.DinnerId ?? 0) ?? new RecipeDto();
                viewModel.Dinner.MealId = 3;
                viewModel.Dinner.RecipeDayId = viewModel.Id;

                viewModel.Snack = _recipeRepository?.GetRecipeById(viewModel.SnackId ?? 0) ?? new RecipeDto();
                viewModel.Snack.MealId = 4;
                viewModel.Snack.RecipeDayId = viewModel.Id;

                viewModel.Supper = _recipeRepository?.GetRecipeById(viewModel.SupperId ?? 0) ?? new RecipeDto();
                viewModel.Supper.MealId = 5;
                viewModel.Supper.RecipeDayId = viewModel.Id;
            }
        }
    }
}