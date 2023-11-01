using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly IRecipeRepository _recipeRepository; 
        public RecipeController(IRecipeRepository recipeRepository, IProductRepository productRepository) {
            _recipeRepository = recipeRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var result = _recipeRepository.GetAllRecipes();
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = result.ToList(); 

            return View(viewModel); 
        }

        public IActionResult Details(int id)
        {
            RecipeViewModel model = new RecipeViewModel();
            model.Recipe = _recipeRepository.GetRecipeById(id);

            return View(model);
        }

        public IActionResult Create()
        {
            RecipeViewModel recipeViewModel = new RecipeViewModel();
            recipeViewModel.SelectedCheckboxes = _productRepository.GetAll().Select(product => new SelectedCheckboxViewModel 
            { 
                IsChecked = false, 
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
            }).ToList();
            return View(recipeViewModel);
        }

        [HttpPost]
        public IActionResult Create(RecipeViewModel model)
        {
            Recipe newRecipe = new Recipe() { Name = model.Recipe.Name } ;
            var result = _recipeRepository.Create(newRecipe); 

            List<Recipe_Ingredients> ingredients = new List<Recipe_Ingredients>();
            var selectedIngredients = model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList(); 
            foreach ( var item in selectedIngredients )
            {
                Recipe_Ingredients ingredient = new Recipe_Ingredients { Amount = item.Grams, ProductId = item.Id, RecipeId = newRecipe.Id }; 
                ingredients.Add( ingredient );
            }

            bool ingredientsResult = _recipeRepository.AddIngredientsToRecipe(newRecipe, ingredients); 

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            bool result = _recipeRepository.Remove(recipe); 
            if(result)
            {
                List<Recipe_Ingredients> ingredients = _recipeRepository.GetIngredientsByRecipe(recipe.Id);
                bool deleteResult = _recipeRepository.RemoveIngredientsForRecipe(ingredients); 
            }
            return RedirectToAction("Index"); 
        }
    }
}
