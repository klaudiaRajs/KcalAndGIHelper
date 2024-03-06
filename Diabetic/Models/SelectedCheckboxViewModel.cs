using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Diabetic.Models
{
    public class SelectedCheckboxViewModel
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Grams { get; set; }
        public double Amount { get; set; }
        public Product Product { get; set; } = new Product();
        public string ProductId { get; set; }
        public int TotalKcal
        {
            get
            {
                return Product.KcalPer100g * (Grams / 100);
            }
            set { }
        }
        public double GL
        {
            get
            {
                return Math.Floor((Product.GI * (Product.CarbsPer100g * (Grams/100)) / 100)); 
            }
            set { }
        }
    }
}
