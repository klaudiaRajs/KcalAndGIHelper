using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe_Ingredients> Recipe_Ingredients { get; set; }
       // public ICollection<Meal> Meals { get; set; }
    }
}

