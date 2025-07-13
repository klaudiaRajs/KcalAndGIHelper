using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MealId { get; set; }
        public int TotalKcal { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
        
    }
}
