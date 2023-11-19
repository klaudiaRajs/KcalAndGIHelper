namespace Diabetic.Models.DTOs
{
    public class IngredientDTO : BaseDTO
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Kcals
        {
            get
            {
                return Math.Round((Product.KcalPer100g * ((double)Amount / (double)100)));
            }
        }

        public string ProductName { get { return Product.Name; } }
        public int ProductId { get { return Product.Id; } }

        public double GL
        {
            get
            {
                return Math.Floor((Product.GI * Product.CarbsPer100g) / 100);
            }
        }
        public string GetGIRating()
        {
            if (Product.GI > _maxGreenGI && Product.GI <= _maxOrangeGI)
            {
                return "table-warning";
            }
            if (Product.GI <= _maxGreenGI)
            {
                return "table-success";
            }
            if (Product.GI > _maxOrangeGI)
            {
                return "table-danger";
            }
            return "";
        }

        public string GetGLRating()
        {
            if (GL > _maxGreenLG && GL <= _maxOrangeLG)
            {
                return "table-warning";
            }
            if (GL <= _maxGreenLG)
            {
                return "table-success";
            }
            if (GL > _maxOrangeLG)
            {
                return "table-danger";
            }
            return "";
        }
    }
}
