using Microsoft.AspNetCore.Mvc.Rendering;

namespace Diabetic.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public string Hello { get; set; } = "Hello";
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; } = new Product();
        public Category Category { get; set; } = new Category();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int CaloryRangeMin { get; set; }
        public int CaloryRangeMax { get; set; }
    }
}
