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
        public RecipeDTO Breakfast { get; set; }
        public int? BreakfastId { get; set; }
        public RecipeDTO Lunch { get; set; }
        public int? LunchId { get; set; }

        public RecipeDTO Dinner { get; set; }
        public int? DinnerId { get; set; }
        public RecipeDTO Supper { get; set; }
        public int? SupperId { get; set; }
        public RecipeDTO Snack { get; set; }
        public int? SnackId { get; set; }
    }
}
