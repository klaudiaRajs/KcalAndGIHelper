namespace Diabetic.Models.DTOs;

public class AddProductToRecipeDto
{
    public int RecipeId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
}