using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class DayDietDto
    {
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
    }
}
