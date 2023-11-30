using Diabetic.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers
{
    public class StatisticsController : BaseController
    {
        public StatisticsController(IRecipeRepository recipeRepository, IProductRepository productRepository, ICategoryRepository categoryRepository) : base(recipeRepository, productRepository, categoryRepository)
        {
        }
    }
}
