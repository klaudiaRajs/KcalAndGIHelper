﻿namespace Diabetic.Models
{
    public class IngredientMealDay
    {
        public int Id { get; set; }
        public DateTime AddedAt { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int Amount { get; set; }
        public float? RecipePortion { get; set; }
        public string UserId { get; set; }
    }
}
