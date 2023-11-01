namespace Diabetic.Models.DTOs
{
    public class IngredientDTO
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Kcals {
            get
            {
                return Math.Round((Product.KcalPer100g * ((double)Amount / (double)100)));
            }
        }

        
    }
}
