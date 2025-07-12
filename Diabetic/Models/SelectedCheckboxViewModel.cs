using Diabetic.Models.Helpers;

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
            get => IndexHelper.GetKcalsForProduct(Product, Grams);
            set { }
        }
        public double Gl
        {
            get => IndexHelper.GetGlOnIngredient(Product, Grams);
            set { }
        }
    }
}
