using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
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
            foreach (DayDietDTO day in viewModel.Days)
            {
                //TODO Refactor 
                day.TotalGL = 0;
                day.Breakfast = _recipeRepository.GetRecipeById(day.BreakfastId);
                day.TotalGL += day.Breakfast.TotalGL;
                day.Lunch = _recipeRepository.GetRecipeById(day.LunchId);
                day.TotalGL += day.Lunch.TotalGL;
                day.Dinner = _recipeRepository.GetRecipeById(day.DinnerId);
                day.TotalGL += day.Dinner.TotalGL;
                day.Supper = _recipeRepository.GetRecipeById(day.SupperId);
                day.TotalGL += day.Supper.TotalGL;
                day.Snack = _recipeRepository.GetRecipeById(day.SnackId);
                day.TotalGL += day.Supper.TotalGL;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(DayDietViewModel model) => GenerateShoppingListForMultipleDays(model.SelectedDaysIds);
        
        public IActionResult Details(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.RecipesForDay = _dietDayRepository.GetDay(id);
            LoadAllRecipesForDayByDayId(viewModel);

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
            DayDietDTO day = _dietDayRepository.GetDay(id);
            bool result = _dietDayRepository.Delete(day);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            DayDietDTO day = _dietDayRepository.GetDay(id);
            DayDietViewModel model = new DayDietViewModel { RecipesForDay = day, Id = day.Id };
            if (model.RecipesForDay != null)
            {
                LoadAllRecipesForDayByDayId(model);
                model.SelectedKcals = model.SetTotalKcals();
                model.SelectedGL = model.SetTotalGL();
            }

            model.Dinners = _recipeRepository.GetByMeal(3);
            model.Recipes = _recipeRepository.GetNonDinnerRecipes();

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Update(DayDietViewModel day)
        {
            if( day == null)
            {
                return View("Error");
            }

            bool result = _dietDayRepository.Update(day.RecipesForDay, day.Id);
            return RedirectToAction("Index"); 

        }
        public IActionResult GenerateShoppingListForMultipleDays(List<int> daysIds)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            List<IngredientDTO> productsToShop = new List<IngredientDTO>();
            foreach (int dayId in daysIds)
            {
                viewModel.RecipesForDay = _dietDayRepository.GetDay(dayId);
                LoadAllRecipesForDayByDayId(viewModel);
                productsToShop.AddRange(ExtractIngredientsFromRecipesForDay(viewModel));
            }
            productsToShop = CollapseRepeatedIngredients(productsToShop);
            //Sort alphabetically
            productsToShop = productsToShop.OrderBy(n => n.Product.Name).ToList();
            
            return View("ShoppingList", productsToShop);
        }

        public IActionResult GenerateShoppingListForOneDay(int id)
        {
            DayDietDTO day = _dietDayRepository.GetDay(id);
            DayDietViewModel model = new DayDietViewModel { RecipesForDay = day };
            if (model.RecipesForDay != null)
            {
                LoadAllRecipesForDayByDayId(model); 
                model.SelectedKcals = model.SetTotalKcals();
                model.SelectedGL = model.SetTotalGL();
            }

            model.Dinners = _recipeRepository.GetByMeal(3);
            model.Recipes = _recipeRepository.GetNonDinnerRecipes();

            return View("Create", model);
        }

        private List<IngredientDTO> ExtractIngredientsFromRecipesForDay(DayDietViewModel viewModel)
        {
            //Extract IngredientDTO only from all recipes of the day and merge them into list
            return (((viewModel.RecipesForDay.Breakfast.Ingredients)
                .Concat(viewModel.RecipesForDay.Lunch.Ingredients))
                .Concat(viewModel.RecipesForDay.Dinner.Ingredients)
                .Concat(viewModel.RecipesForDay.Supper.Ingredients)).ToList();
        }

        private List<IngredientDTO> CollapseRepeatedIngredients(List<IngredientDTO> ingredients)
        {
            //Group repeated ingredients, then collapse repeated ingredients to one ingredient and sum amount to buy.
            return ingredients
                .GroupBy(n => n.Product.Id)           
                .Select(group => new IngredientDTO()
                {
                    Product = group.Select(n => n.Product).FirstOrDefault(),
                    Amount = group.Select(n => n.Amount).Sum()
                })
                .ToList();
        }

        private void LoadAllRecipesForDayByDayId(DayDietViewModel viewModel)
        {
            if (viewModel.RecipesForDay != null)
            {
                viewModel.RecipesForDay.Breakfast = _recipeRepository?.GetRecipeById(viewModel.RecipesForDay.BreakfastId ?? 0) ?? new RecipeDTO();
                viewModel.RecipesForDay.Breakfast.MealId = 1;
                viewModel.RecipesForDay.Breakfast.RecipeDayId = viewModel.RecipesForDay.Id; 

                viewModel.RecipesForDay.Lunch = _recipeRepository?.GetRecipeById(viewModel.RecipesForDay.LunchId ?? 0) ?? new RecipeDTO();
                viewModel.RecipesForDay.Lunch.MealId = 2;
                viewModel.RecipesForDay.Lunch.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Dinner = _recipeRepository?.GetRecipeById(viewModel.RecipesForDay.DinnerId ?? 0) ?? new RecipeDTO();
                viewModel.RecipesForDay.Dinner.MealId = 3;
                viewModel.RecipesForDay.Dinner.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Snack = _recipeRepository?.GetRecipeById(viewModel.RecipesForDay.SnackId ?? 0) ?? new RecipeDTO();
                viewModel.RecipesForDay.Snack.MealId = 4;
                viewModel.RecipesForDay.Snack.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Supper = _recipeRepository?.GetRecipeById(viewModel.RecipesForDay.SupperId ?? 0) ?? new RecipeDTO();
                viewModel.RecipesForDay.Supper.MealId = 5;
                viewModel.RecipesForDay.Supper.RecipeDayId = viewModel.RecipesForDay.Id;
            }
        }


    }
}