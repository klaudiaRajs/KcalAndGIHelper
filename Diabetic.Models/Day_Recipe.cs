using System.ComponentModel.DataAnnotations.Schema;

namespace Diabetic.Models
{
    public class Day_Recipe
    {
        public int Id { get; set; }
        public int? BreakfastRecipeId { get; set; }
        public int? LunchRecipeId { get; set; }
        public int? DinnerRecipeId { get; set; }
        public int? SnackRecipeId { get; set; }
        public int? SupperRecipeId { get; set; }
        public int DayId { get; set; }
        [ForeignKey("BreakfastRecipeId")]
        public Recipe Recipe { get; set; }
    }
}
