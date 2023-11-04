namespace Diabetic.Models
{
    public class SelectedCheckboxViewModel
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Grams { get; set; }
        public Product Product { get; set; } = new Product();
        public int TotalKcal
        {
            get
            {
                return Product.KcalPer100g * (Grams / 100);
            }
        }
        public double GL
        {
            get
            {
                return Math.Floor((Product.GI * (Product.CarbsPer100g * (Grams/100)) / 100)); 
            }
        }
    }
}
