using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class SelectionDTO
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
                return Product.KcalPer100g * (Grams / 100);
            }
            set { }
        }
        public double GL
        {
            get
            {
                return Math.Floor((Product.GI * (Product.CarbsPer100g * (Grams / 100)) / 100));
            }
            set { }
        }

        
    }
}
