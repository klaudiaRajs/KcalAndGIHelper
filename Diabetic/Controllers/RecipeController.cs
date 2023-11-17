using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Diabetic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Diabetic.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository; 
        public RecipeController(IRecipeRepository recipeRepository, IProductRepository productRepository, ICategoryRepository categoryRepository) {
            _recipeRepository = recipeRepository;
            _productRepository = productRepository;
            this._categoryRepository = categoryRepository;
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
            recipeViewModel.Categories = _categoryRepository.GetAll(); 
            recipeViewModel.SelectedCheckboxes = _productRepository.GetAll().Select(product => new SelectedCheckboxViewModel 
            { 
                IsChecked = false, 
                Id = product.Product.Id,
                Name = product.Product.Name,
                CategoryId = product.Product.CategoryId,
                Product = product.Product
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
            SeederService.GenerateSeederForRecipeCreate(newRecipe, ingredients); 
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

        public IActionResult Edit(int id)
        {
            RecipeViewModel model = new RecipeViewModel();
            model.Categories = _categoryRepository.GetAll();

            var recipe = _recipeRepository.GetRecipeById(id);
            if( recipe == null)
            {
                return NotFound();
            }
            model.Recipe = recipe; 
            model.SelectedCheckboxes = _productRepository.GetAll()
            .Select(ingredient => new SelectedCheckboxViewModel
            {
                IsChecked = false,
                Id = ingredient.Product.Id,
                Name = ingredient.Product.Name,
                CategoryId = ingredient.Product.CategoryId, 
                Product = ingredient.Product
            }).ToList();

            var ingredients = _recipeRepository.GetIngredientsByRecipe(id);
            for (int i = 0; i < model.SelectedCheckboxes.Count; i++)
            {
                SelectedCheckboxViewModel? item = model.SelectedCheckboxes[i];
                var ingredient = ingredients.Where(a => a.ProductId == item.Id).FirstOrDefault();
                if( ingredient == null)
                {
                    continue; 
                } else
                {
                    model.SelectedCheckboxes[i].IsChecked = true;
                    model.SelectedCheckboxes[i].Grams = ingredient.Amount;
                }
            }

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(RecipeViewModel model)
        {
            var recipe = _recipeRepository.GetRecipeById(model.Recipe.Id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipe.Name = model.Recipe.Name;

            var currentRecipe = new Recipe { Name = recipe.Name, Id = recipe.Id };
            bool result = _recipeRepository.Update(currentRecipe);

            var currentIngredients = _recipeRepository.GetIngredientsByRecipe(recipe.Id);
            var newIngredients = model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList();

            List<Recipe_Ingredients> toBeUpdated = new List<Recipe_Ingredients>(); 
            List<Recipe_Ingredients> toBeAdded = new List<Recipe_Ingredients>(); 
            List<Recipe_Ingredients> toBeRemoved = new List<Recipe_Ingredients>();

            foreach(var old in currentIngredients)
            {
                bool isToBeUpdated = false;
                foreach( var newItem in newIngredients)
                {
                    if( old.ProductId == newItem.Id)
                    {
                        toBeUpdated.Add(new Recipe_Ingredients { Id = old.Id, ProductId = newItem.Id, Amount = newItem.Grams, RecipeId = currentRecipe.Id });
                        isToBeUpdated = true;
                        break; 
                    }
                }
                if( !isToBeUpdated)
                {
                    toBeRemoved.Add(old);
                }                
            }

            foreach( var item in newIngredients)
            {
                var itemToBeUpdated = toBeUpdated.Where(a => a.ProductId == item.Id).ToList();
                var itemToBeRemoved = toBeRemoved.Where(a => a.ProductId == item.Id).ToList();

                if( !itemToBeUpdated.Any() && !itemToBeRemoved.Any() ) {
                    toBeAdded.Add(new Recipe_Ingredients { ProductId = item.Id, Amount = item.Grams, RecipeId = currentRecipe.Id });
                }
            }
            var addingResult = _recipeRepository.AddIngredientsToRecipe(currentRecipe, toBeAdded);
            var updatingResult = _recipeRepository.UpdateIngredientsForRecipe(currentRecipe, toBeUpdated);
            var removingResult = _recipeRepository.RemoveIngredientsForRecipe(toBeRemoved); 
            

            return RedirectToAction("Index");
        }

        public IActionResult GetRecipeKcals(int recipeId)
        {
            RecipeDTO recipe = _recipeRepository.GetRecipeById(recipeId);
            return Ok(new {success = true, kcals = recipe.TotalKcal, gl = recipe.TotalGL }); 
        }
    }
}

