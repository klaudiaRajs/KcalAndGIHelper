using Diabetic.Models.Helpers;

namespace Diabetic.Models.DTOs
{
    public class DayDietDto
    {
        //TODO change mealObjects withId to ONE dictionary 
        public int Id { get; set; }
        public RecipeDto Breakfast { get; set; } = new RecipeDto();
        public int? BreakfastId { get; set; }
        public RecipeDto Lunch { get; set; } = new RecipeDto();
        public int? LunchId { get; set; }

        public RecipeDto Dinner { get; set; } = new RecipeDto();
        public int? DinnerId { get; set; }
        public RecipeDto Supper { get; set; } = new RecipeDto();
        public int? SupperId { get; set; }
        public RecipeDto Snack { get; set; } = new RecipeDto();
        public int? SnackId { get; set; }
        public double TotalGl { get; set; }
        public double TotalKcal => IndexHelper.GetKcalForDay(this);
        public int RemainingKcals { get; set; } = 0;
        public void SetTotalGl()
        {
            TotalGl = IndexHelper.GetGlForDay(this);
        }
    }
}