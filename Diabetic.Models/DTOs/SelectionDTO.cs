namespace Diabetic.Models.DTOs
{
    public class SelectionDto
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Grams { get; set; }
        public Product Product { get; set; } = new Product();
        public int MealId { get; set; }
        public int RecipeDayId { get; set; }
        public int TotalKcal
        {
            get
            {
                return Product.KcalPer100G * (Grams / 100);
            }
            set { }
        }
        public double Gl
        {
            get
            {
                return Math.Floor((Product.Gi * (Product.CarbsPer100G * (Grams / 100)) / 100));
            }
            set { }
        }

        
    }
}
