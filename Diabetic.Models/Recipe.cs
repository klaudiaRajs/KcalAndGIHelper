using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<RecipeIngredients> RecipeIngredients { get; set; }
       // public ICollection<Meal> Meals { get; set; }
    }
}

