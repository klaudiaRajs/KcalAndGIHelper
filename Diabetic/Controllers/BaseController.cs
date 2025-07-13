using Diabetic.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    [Authorize]
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly IProductRepository ProductRepository;
        protected readonly ICategoryRepository CategoryRepository;
        protected readonly IMealRepository? MealRepository;
        protected readonly IRecipeRepository RecipeRepository;

        public BaseController(IRecipeRepository recipeRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IMealRepository? mealRepository = null)
        {
            RecipeRepository = recipeRepository;
            ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
            this.MealRepository = mealRepository;
        }
    }
}
