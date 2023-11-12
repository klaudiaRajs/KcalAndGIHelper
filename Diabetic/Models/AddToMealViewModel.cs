﻿namespace Diabetic.Models
{
    public class AddToMealViewModel
    {
        public IEnumerable<Meal> Meals { get; set; }
        public int SelectedMealId { get; set; }
        public int SelectedProductId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int Amount { get; set; }
    }
}
