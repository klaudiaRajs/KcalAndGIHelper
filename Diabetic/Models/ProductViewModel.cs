using Microsoft.AspNetCore.Mvc.Rendering;

namespace Diabetic.Models
{
    public class ProductViewModel
    {
        public string Hello { get; set; } = "Hello";
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; } = new Product();
        public Category Category { get; set; } = new Category();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int CaloryRangeMin { get; set; }
        public int CaloryRangeMax { get; set; }
        public bool Green { get; set; } 
        public bool Orange { get; set; }    
        public bool Red { get; set; }
        public int _maxGreen { get; set; } = 39;
        public int _maxOrange { get; set; } = 55;
        public bool IsGreen(int gI)
        {
            return gI <= _maxGreen;
        }

        public bool IsOrange(int gI)
        {
            return (gI > _maxGreen && gI <= _maxOrange);
        }

        public bool IsRed(int gI)
        {
            return gI > _maxOrange;
        }
    }
}
