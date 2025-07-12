using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Diabetic.Models.Helpers;
using Diabetic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Diabetic.Controllers
{
    public class RecipeController : BaseController
    {
        public RecipeController(IRecipeRepository recipeRepository, IProductRepository productRepository,
            ICategoryRepository categoryRepository, IMealRepository? mealRepository)
            : base(recipeRepository, productRepository, categoryRepository, mealRepository)
        {
        }

        public IActionResult Index()
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = _recipeRepository.GetAllRecipes().ToList();

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
            recipeViewModel.Meals = _mealRepository.GetAll()
                .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            recipeViewModel.SelectedCheckboxes = _productRepository.GetAll().Select(product =>
                new SelectedCheckboxViewModel
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
            if (String.IsNullOrEmpty(model.Recipe.Name))
            {
                ModelState.AddModelError(nameof(model.Recipe.Name), "error");
                model.Categories = _categoryRepository.GetAll();
                model = CreateSelectBoxesForIngredients(model);
                model = SetCheckboxesForModel(model);
                model.Meals = _mealRepository.GetAll()
                    .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
                return View(model);
            }

            Recipe newRecipe = new Recipe() { Name = model.Recipe.Name };
            bool result = _recipeRepository.Create(newRecipe);
            _recipeRepository.AssignRecipeToMeals(newRecipe.Id, model.SelectedMeals);

            List<Recipe_Ingredients> ingredients = new List<Recipe_Ingredients>();
            List<SelectedCheckboxViewModel> selectedIngredients =
                model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList();
            foreach (SelectedCheckboxViewModel item in selectedIngredients)
            {
                Recipe_Ingredients ingredient = new Recipe_Ingredients
                    { Amount = item.Grams, ProductId = (int)item.Id, RecipeId = newRecipe.Id };
                ingredients.Add(ingredient);
            }

            bool ingredientsResult = _recipeRepository.AddIngredientsToRecipe(newRecipe, ingredients);
            SeederService.GenerateSeederForRecipeCreate(newRecipe, ingredients);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            RecipeDTO? recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            bool result = _recipeRepository.Remove(recipe);
            if (result)
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

            RecipeDTO? recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            model.Recipe = recipe;

            model = CreateSelectBoxesForIngredients(model);
            model = SetCheckBoxBasedOnIngredients(model, id);

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult RemoveProductFromRecipe([FromBody] AddProductToRecipeDto? payload)
        {
            try
            {
                List<Recipe_Ingredients> ingredients = _recipeRepository.GetIngredientsEntryForRecipeAndProduct(payload.RecipeId, payload.ProductId);
                var recipe = _recipeRepository.GetRecipeById(payload.RecipeId); 
                
                if (ingredients.Count == 0)
                {
                    return NotFound();
                }

                bool result = _recipeRepository.RemoveIngredientsForRecipe(ingredients);
                if (!result)
                {
                    throw new Exception("Failed to remove product from recipe");
                }
                
                recipe.Ingredients.Remove(recipe.Ingredients.FirstOrDefault(i => i.Product.Id == payload.ProductId));
                recipe.TotalKcal = IndexHelper.GetKcalsForRecipe(recipe);
                recipe.TotalGL = IndexHelper.GetGlForRecipe(recipe);

                return Ok(new { success = true, totalKcal = recipe.TotalKcal, totalGl = recipe.TotalGL });
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = StatusCodes.Status500InternalServerError, e.Message });
            }
        }
        
        [HttpPost]
        public IActionResult AddProductToRecipe([FromBody] AddProductToRecipeDto? payload)
        {
            try
            {
                payload = AddNewRecipeIfDoesntExist(payload);
                ValidatePayload(payload);
                RecipeDTO recipe = GetRecipeWithNewIngredient(payload);
 
                recipe.TotalKcal = IndexHelper.GetKcalsForRecipe(recipe);
                recipe.TotalGL = IndexHelper.GetGlForRecipe(recipe);

                return Ok(new
                {
                    success = true, 
                    totalKcal = recipe.TotalKcal, 
                    totalGl = recipe.TotalGL,
                    recipeAdded = recipe.IsNewRecipe,
                    recipeId = recipe.Id
                });
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = StatusCodes.Status500InternalServerError, e.Message });
            }
        }

        private RecipeViewModel CreateSelectBoxesForIngredients(RecipeViewModel model)
        {
            model.SelectedCheckboxes = _productRepository.GetAll()
                .Select(ingredient => new SelectedCheckboxViewModel
                {
                    IsChecked = false,
                    Id = ingredient.Product.Id,
                    ProductId = ingredient.Product.Id.ToString(),
                    Grams = 0,
                    Name = ingredient.Product.Name,
                    CategoryId = ingredient.Product.CategoryId,
                    Product = ingredient.Product
                }).ToList();
            return model;
        }

        private AddProductToRecipeDto? AddNewRecipeIfDoesntExist(AddProductToRecipeDto? payload)
        {
            if (payload != null && payload.RecipeId == 0)
            {
                Recipe newRecipe = new Recipe { Name = "New Recipe" };
                bool creationResult = _recipeRepository.Create(newRecipe);
                if (!creationResult)
                {
                    throw new Exception("Failed to create new recipe");
                }

                payload.RecipeId = newRecipe.Id;
            }

            return payload;
        }

        private void ValidatePayload(AddProductToRecipeDto? payload)
        {
            if (payload == null || payload.Amount <= 0 || payload.ProductId <= 0 || payload.RecipeId <= 0)
            {
                throw new Exception("Invalid payload");
            }
        }

        private RecipeDTO? GetRecipeWithNewIngredient(AddProductToRecipeDto payload)
        {
            RecipeDTO? recipe = _recipeRepository.GetRecipeById(payload.RecipeId);
            Product? product = _productRepository.GetById(payload.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            recipe = AddOrUpdateProduct(recipe, payload, product);
            return recipe;
        }

        private RecipeDTO AddOrUpdateProduct(RecipeDTO recipe, AddProductToRecipeDto payload, Product product)
        {
            var productAlreadySelected = recipe.Ingredients.FirstOrDefault(i => i.Product.Id == payload.ProductId);
            if (productAlreadySelected == null)
            {
                recipe.Ingredients.Add(recipe.GetIngredientByProduct(product, payload.Amount));
            }
            else
            {
                productAlreadySelected.Amount = payload.Amount;
            }

            SaveIngredientToRecipe(payload, recipe);
            return recipe;
        }

        private void SaveIngredientToRecipe(AddProductToRecipeDto payload, RecipeDTO recipe)
        {
            Recipe_Ingredients ingredient = new Recipe_Ingredients
            {
                RecipeId = payload.RecipeId,
                ProductId = payload.ProductId,
                Amount = payload.Amount
            };

            bool result = _recipeRepository.UpsertIngredientToRecipe(recipe, ingredient);
            if (!result)
            {
                throw new Exception("Failed to add product to recipe");
            }
        }

        private RecipeViewModel SetCheckBoxBasedOnIngredients(RecipeViewModel model, int id)
        {
            
            List<Recipe_Ingredients> ingredients = _recipeRepository.GetIngredientsByRecipe(id);
            for (int i = 0; i < model.SelectedCheckboxes.Count; i++)
            {
                SelectedCheckboxViewModel? item = model.SelectedCheckboxes[i];
                Recipe_Ingredients? ingredient = ingredients.FirstOrDefault(a => a.ProductId == item.Id);
                if (ingredient == null)
                {
                    continue;
                }
                else
                {
                    model.SelectedCheckboxes[i].IsChecked = true;
                    model.SelectedCheckboxes[i].Grams = ingredient.Amount;
                    model.SelectedCheckboxes[i].TotalKcal =
                        IndexHelper.GetKcalsForProduct(ingredient.Product, ingredient.Amount);
                }
            }

            return model;
        }

        private RecipeViewModel SetCheckboxesForModel(RecipeViewModel model)
        {
            List<SelectedCheckboxViewModel> ingredients =
                model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList();
            for (int i = 0; i < model.SelectedCheckboxes.Count; i++)
            {
                SelectedCheckboxViewModel? item = model.SelectedCheckboxes[i];
                SelectedCheckboxViewModel? ingredient = ingredients.FirstOrDefault(a => a.Id == item.Id);
                if (ingredient == null)
                {
                    continue;
                }
                else
                {
                    model.SelectedCheckboxes[i].IsChecked = true;
                    model.SelectedCheckboxes[i].Grams = ingredient.Grams;
                    model.SelectedCheckboxes[i].TotalKcal =
                        IndexHelper.GetKcalsForProduct(ingredient.Product, (int)Math.Floor(ingredient.Amount));
                }
            }

            return model;
        }

        [HttpPost]
        public IActionResult Edit(RecipeViewModel model)
        {
            if (model == null)
            {
                //zrób jakieś logowanie błędu 
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                RecipeDTO? recipe = _recipeRepository.GetRecipeById(model.Recipe.Id);
                if (recipe == null)
                {
                    return NotFound();
                }

                recipe.Name = model.Recipe.Name;

                Recipe currentRecipe = new Recipe { Name = recipe.Name, Id = recipe.Id };
                bool result = _recipeRepository.Update(currentRecipe);

                List<Recipe_Ingredients> currentIngredients = _recipeRepository.GetIngredientsByRecipe(recipe.Id);
                List<SelectedCheckboxViewModel> newIngredients =
                    model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList();

                List<Recipe_Ingredients> toBeUpdated = new List<Recipe_Ingredients>();
                List<Recipe_Ingredients> toBeAdded = new List<Recipe_Ingredients>();
                List<Recipe_Ingredients> toBeRemoved = new List<Recipe_Ingredients>();

                foreach (Recipe_Ingredients old in currentIngredients)
                {
                    bool isToBeUpdated = false;
                    foreach (SelectedCheckboxViewModel newItem in newIngredients)
                    {
                        if (old.ProductId == newItem.Id)
                        {
                            toBeUpdated.Add(new Recipe_Ingredients
                            {
                                Id = old.Id, ProductId = newItem.Id, Amount = newItem.Grams, RecipeId = currentRecipe.Id
                            });
                            isToBeUpdated = true;
                            break;
                        }
                    }

                    if (!isToBeUpdated)
                    {
                        toBeRemoved.Add(old);
                    }
                }

                foreach (SelectedCheckboxViewModel item in newIngredients)
                {
                    List<Recipe_Ingredients> itemToBeUpdated = toBeUpdated.Where(a => a.ProductId == item.Id).ToList();
                    List<Recipe_Ingredients> itemToBeRemoved = toBeRemoved.Where(a => a.ProductId == item.Id).ToList();

                    if (!itemToBeUpdated.Any() && !itemToBeRemoved.Any())
                    {
                        toBeAdded.Add(new Recipe_Ingredients
                            { ProductId = (int)item.Id, Amount = item.Grams, RecipeId = currentRecipe.Id });
                    }
                }

                bool addingResult = _recipeRepository.AddIngredientsToRecipe(currentRecipe, toBeAdded);
                bool updatingResult = _recipeRepository.UpdateIngredientsForRecipe(currentRecipe, toBeUpdated);
                bool removingResult = _recipeRepository.RemoveIngredientsForRecipe(toBeRemoved);
            }


            return RedirectToAction("Index");
        }

        public IActionResult GetRecipeKcals(int recipeId)
        {
            RecipeDTO recipe = _recipeRepository.GetRecipeById(recipeId);
            return Ok(new { success = true, kcals = recipe.TotalKcal, gl = recipe.TotalGL });
        }

        public IActionResult ChangeIngredients(int recipeId, int mealId, int recipeDayId)
        {
            RecipeViewModel model = new RecipeViewModel();
            model.Categories = _categoryRepository.GetAll();

            RecipeDTO? recipe = _recipeRepository.GetRecipeById(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            model.Recipe = recipe;
            model.Recipe.MealId = mealId;
            model.Recipe.RecipeDayId = recipeDayId;

            model = CreateSelectBoxesForIngredients(model);
            model = SetCheckBoxBasedOnIngredients(model, recipeId);
            model.IsIngredientBeingSwitched = true;

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult ChangeIngredients(RecipeViewModel model)
        {
            List<SelectionDTO> selections = new List<SelectionDTO>();
            List<SelectedCheckboxViewModel> selectedIngredients =
                model.SelectedCheckboxes.Where(a => a.IsChecked == true).ToList();
            foreach (SelectedCheckboxViewModel itm in selectedIngredients)
            {
                selections.Add(new SelectionDTO
                {
                    Grams = itm.Grams, Id = (int)itm.Id, MealId = model.Recipe.MealId,
                    RecipeDayId = model.Recipe.RecipeDayId
                });
            }

            _recipeRepository.CreateRecipeIfNotExistant(selections, model.Recipe.Id, model.Recipe.Name,
                model.Recipe.RecipeDayId);

            return RedirectToAction("Index", "DietDay");
        }
    }
}