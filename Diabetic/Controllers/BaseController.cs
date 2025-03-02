using Diabetic.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    [Authorize]
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IMealRepository _mealRepository;
        protected readonly IRecipeRepository _recipeRepository;

        public BaseController(IRecipeRepository recipeRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IMealRepository mealRepository = null)
        {
            _recipeRepository = recipeRepository;
            _productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._mealRepository = mealRepository;
        }
    }
}
