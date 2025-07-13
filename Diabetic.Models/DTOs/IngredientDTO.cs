using Diabetic.Models.DTOs.Interfaces;

namespace Diabetic.Models.DTOs
{
    public class IngredientDto : BaseDto, IIngredient
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double Kcals
        {
            get
            {
                return Math.Round((Product.KcalPer100G * ((double)Amount / (double)100)));
            }
        }

        public string ProductName { get { return Product.Name; } }
        public int ProductId { get { return Product.Id; } }

        public double Gl { get; set; }

        public string GetGiRating()
        {
            if (Product.Gi > MaxGreenGi && Product.Gi <= MaxOrangeGi)
            {
                return "table-warning";
            }
            if (Product.Gi <= MaxGreenGi)
            {
                return "table-success";
            }
            if (Product.Gi > MaxOrangeGi)
            {
                return "table-danger";
            }
            return "";
        }

        public string GetGlRating()
        {
            if (Gl > MaxGreenLg && Gl <= MaxOrangeLg)
            {
                return "table-warning";
            }
            if (Gl <= MaxGreenLg)
            {
                return "table-success";
            }
            if (Gl > MaxOrangeLg)
            {
                return "table-danger";
            }
            return "";
        }
    }
}
