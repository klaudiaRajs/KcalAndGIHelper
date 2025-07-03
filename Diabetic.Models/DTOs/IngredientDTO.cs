using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Models.DTOs
{
    public class IngredientDTO : BaseDTO, IIngredient
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

        public double Gl { get; set; }

        public string GetGiRating()
        {
            if (Product.Gi > _maxGreenGI && Product.Gi <= _maxOrangeGI)
            {
                return "table-warning";
            }
            if (Product.Gi <= _maxGreenGI)
            {
                return "table-success";
            }
            if (Product.Gi > _maxOrangeGI)
            {
                return "table-danger";
            }
            return "";
        }

        public string GetGLRating()
        {
            if (Gl > _maxGreenLG && Gl <= _maxOrangeLG)
            {
                return "table-warning";
            }
            if (Gl <= _maxGreenLG)
            {
                return "table-success";
            }
            if (Gl > _maxOrangeLG)
            {
                return "table-danger";
            }
            return "";
        }
    }
}
