using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class DayDietDTO
    {
        public int Id { get; set; }
        public RecipeDTO Breakfast { get; set; } = new RecipeDTO();
        public int? BreakfastId { get; set; }
        public RecipeDTO Lunch { get; set; } = new RecipeDTO();
        public int? LunchId { get; set; }

        public RecipeDTO Dinner { get; set; } = new RecipeDTO();
        public int? DinnerId { get; set; }
        public RecipeDTO Supper { get; set; } = new RecipeDTO(); 
        public int? SupperId { get; set; }
        public RecipeDTO Snack { get; set; } = new RecipeDTO();
        public int? SnackId { get; set; }
    }
}
