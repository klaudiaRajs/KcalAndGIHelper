using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
