using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    public class DietDayController : BaseController
    {
        private IDietDayRepository DietDayRepository { get; }
        public DietDayController(
            IRecipeRepository recipeRepository, 
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository, 
            IDietDayRepository dietDayRepository, 
            IMealRepository? mealRepository = null) 
            : base(recipeRepository, productRepository, categoryRepository, mealRepository)
        {
            DietDayRepository = dietDayRepository;
            
        }

        public IActionResult Index()
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Days = DietDayRepository.GetAll();
            foreach (DayDietDto day in viewModel.Days)
            {
                //TODO Refactor 
                day.TotalGl = 0;
                day.Breakfast = RecipeRepository.GetRecipeById(day.BreakfastId);
                day.TotalGl += day.Breakfast.TotalGl;
                day.Lunch = RecipeRepository.GetRecipeById(day.LunchId);
                day.TotalGl += day.Lunch.TotalGl;
                day.Dinner = RecipeRepository.GetRecipeById(day.DinnerId);
                day.TotalGl += day.Dinner.TotalGl;
                day.Supper = RecipeRepository.GetRecipeById(day.SupperId);
                day.TotalGl += day.Supper.TotalGl;
                day.Snack = RecipeRepository.GetRecipeById(day.SnackId);
                day.TotalGl += day.Supper.TotalGl;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(DayDietViewModel model) => GenerateShoppingListForMultipleDays(model.SelectedDaysIds);
        
        public IActionResult Details(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.RecipesForDay = DietDayRepository.GetDay(id);

            LoadAllRecipesForDayByDayId(viewModel);
            viewModel.SetTotalKcals(); 
            viewModel.SetTotalGl();
            return View(viewModel);
        }


        public IActionResult Create(RecipeViewModel model)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Dinners = RecipeRepository.GetByMeal(3);
            viewModel.Recipes = RecipeRepository.GetNonDinnerRecipes();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(DayDietViewModel model)
        {
            bool result = DietDayRepository.Create(model.RecipesForDay);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            DayDietDto day = DietDayRepository.GetDay(id);
            bool result = DietDayRepository.Delete(day);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            DayDietDto day = DietDayRepository.GetDay(id);
            DayDietViewModel model = new DayDietViewModel { RecipesForDay = day, Id = day.Id };
            if (model.RecipesForDay != null)
            {
                LoadAllRecipesForDayByDayId(model);
                model.SelectedKcals = model.SetTotalKcals();
                model.SelectedGl = model.SetTotalGl();
            }

            model.Dinners = RecipeRepository.GetByMeal(3);
            model.Recipes = RecipeRepository.GetNonDinnerRecipes();

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Update(DayDietViewModel day)
        {
            if( day == null)
            {
                return View("Error");
            }

            bool result = DietDayRepository.Update(day.RecipesForDay, day.Id);
            return RedirectToAction("Index"); 

        }
        public IActionResult GenerateShoppingListForMultipleDays(List<int> daysIds)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            List<IngredientDto> productsToShop = new List<IngredientDto>();
            foreach (int dayId in daysIds)
            {
                viewModel.RecipesForDay = DietDayRepository.GetDay(dayId);
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

        private void LoadAllRecipesForDayByDayId(DayDietViewModel viewModel)
        {
            if (viewModel.RecipesForDay != null)
            {
                viewModel.RecipesForDay.Breakfast = RecipeRepository?.GetRecipeById(viewModel.RecipesForDay.BreakfastId ?? 0) ?? new RecipeDto();
                viewModel.RecipesForDay.Breakfast.MealId = 1;
                viewModel.RecipesForDay.Breakfast.RecipeDayId = viewModel.RecipesForDay.Id; 

                viewModel.RecipesForDay.Lunch = RecipeRepository?.GetRecipeById(viewModel.RecipesForDay.LunchId ?? 0) ?? new RecipeDto();
                viewModel.RecipesForDay.Lunch.MealId = 2;
                viewModel.RecipesForDay.Lunch.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Dinner = RecipeRepository?.GetRecipeById(viewModel.RecipesForDay.DinnerId ?? 0) ?? new RecipeDto();
                viewModel.RecipesForDay.Dinner.MealId = 3;
                viewModel.RecipesForDay.Dinner.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Snack = RecipeRepository?.GetRecipeById(viewModel.RecipesForDay.SnackId ?? 0) ?? new RecipeDto();
                viewModel.RecipesForDay.Snack.MealId = 4;
                viewModel.RecipesForDay.Snack.RecipeDayId = viewModel.RecipesForDay.Id;

                viewModel.RecipesForDay.Supper = RecipeRepository?.GetRecipeById(viewModel.RecipesForDay.SupperId ?? 0) ?? new RecipeDto();
                viewModel.RecipesForDay.Supper.MealId = 5;
                viewModel.RecipesForDay.Supper.RecipeDayId = viewModel.RecipesForDay.Id;
            }
        }
    }
}