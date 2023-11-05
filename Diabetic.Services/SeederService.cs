using Diabetic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Services
{
    public class SeederService
    {
        public static void GenerateSeederForRecipeCreate(Recipe recipe, List<Recipe_Ingredients> ingredients)
        {
            var path = "C:\\Projects\\Diabetic\\Diabetic\\seeder.txt";

            string content = "new Recipe { Id = " +  recipe.Id +  ", Name = \"" + recipe.Name + "\"}," + Environment.NewLine;
            content += "/**" + recipe.Name + "*/";
            foreach( Recipe_Ingredients ingredient in ingredients )
            {
                content += 
                    "new Recipe_Ingredients { Id = " + ingredient.Id 
                    + ", RecipeId = " + ingredient.RecipeId
                    + ", ProductId = " + ingredient.ProductId 
                    + ", Amount = " + ingredient.Amount
                    + "},"  + Environment.NewLine;
            }


            File.AppendAllText(path, content); 
        }
    }
}
