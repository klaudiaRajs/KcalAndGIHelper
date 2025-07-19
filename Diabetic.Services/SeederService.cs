using Diabetic.Models;

namespace Diabetic.Services
{
    public class SeederService
    {
        public static void GenerateSeederForRecipeCreate(Recipe recipe, List<Recipe_Ingredients> ingredients)
        {
            string path = "@path";

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

        public static void GenerateSeederForProductCreate(Product product)
        {
            string path = "@path";

            string content = 
                "new Product { Id = " + product.Id 
                + ", Name = \"" + product.Name + "\"" +
                ", KcalPer100g = " + product.KcalPer100G 
                + ", CarbsPer100g = " + product.CarbsPer100G 
                + ", Protein = " + product.Protein 
                + ", Fat = " + product.Fat 
                + ", Sugar = " + product.Sugar 
                + ", Fibre = " + product.Fibre 
                + ", GI = " + product.Gi 
                + ", CategoryId = " + product.CategoryId 
                + ", GramsPerPortion = " + product.GramsPerPortion 
                + "}," + Environment.NewLine;

            File.AppendAllText(path, content);
        }
    }
}
