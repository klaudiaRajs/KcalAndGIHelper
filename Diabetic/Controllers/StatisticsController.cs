using Diabetic.Data.Repositories.Interfaces;

namespace Diabetic.Controllers
{
    public class StatisticsController : BaseController
    {
        public StatisticsController(IRecipeRepository recipeRepository, IProductRepository productRepository, ICategoryRepository categoryRepository) : base(recipeRepository, productRepository, categoryRepository)
        {
        }
    }
}
